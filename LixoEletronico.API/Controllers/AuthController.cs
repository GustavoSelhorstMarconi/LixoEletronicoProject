using LixoEletronico.Application;
using LixoEletronico.Application.Contracts;
using LixoEletronico.Domain.Entities;
using LixoEletronico.Shared.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LixoEletronico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<Person> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IPersonService _personService;

        public AuthController(ITokenService tokenService, UserManager<Person> userManager, RoleManager<IdentityRole<int>> roleManager, IConfiguration configuration, IHttpContextAccessor contextAccessor, IPersonService personService)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _contextAccessor = contextAccessor;
            _personService = personService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName!);

            if (user is not null && await _userManager.CheckPasswordAsync(user, model.Password!))
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName!),
                    new Claim(ClaimTypes.Email, user.Email!),
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var token = _tokenService.GenerateAccessToken(authClaims,
                    _configuration);

                var refreshToken = _tokenService.GenerateRefreshToken();

                _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInMinutes"],
                    out int refreshTokenValidityInMinutes);

                user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(refreshTokenValidityInMinutes);

                user.RefreshToken = refreshToken;

                await _userManager.UpdateAsync(user);

                return Ok(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    RefreshToken = refreshToken,
                    Expiration = token.ValidTo
                });
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] PersonDto model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Name!);

            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ResponseDto { Status = "Error", Message = "User already exists!" });
            }

            Person user = new Person(model.Name!, model.IsRepresentant)
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Name
            };

            var result = await _userManager.CreateAsync(user, model.Password!);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ResponseDto { Status = "Error", Message = result.Errors.First().Description });
            }

            return Ok(new ResponseDto { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken(TokenDto tokenDto)
        {
            if (tokenDto is null)
            {
                return BadRequest("Invalid client request");
            }

            string? accessToken = tokenDto.AccessToken
                ?? throw new ArgumentNullException(nameof(tokenDto));

            string? refreshToken = tokenDto.RefreshToken
                ?? throw new ArgumentNullException(nameof(tokenDto));

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken!, _configuration);

            if (principal == null)
            {
                return BadRequest("Invalid access token/refresh token.");
            }

            string username = principal.Identity.Name;

            var user = await _userManager.FindByNameAsync(username!);

            if (user == null || user.RefreshToken != refreshToken
                || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return BadRequest("Invalid access token/refresh token.");
            }

            var newAccessToken = _tokenService.GenerateAccessToken(principal.Claims.ToList(), _configuration);

            var newRefreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;

            await _userManager.UpdateAsync(user);

            return new ObjectResult(new
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                refreshToken = newRefreshToken
            });
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Route("revoke/{username}")]
        public async Task<IActionResult> Revoke(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return BadRequest("Invalid user name.");
            }

            user.RefreshToken = null;

            await _userManager.UpdateAsync(user);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update(PersonDto person)
        {
            var user = _contextAccessor?.HttpContext?.User;
            int id = int.Parse(user?.FindFirst(ClaimTypes.Sid)?.Value);

            await _personService.UpdatePerson(id, person);

            return NoContent();
        }
    }
}

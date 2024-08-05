using LixoEletronico.Application.Contracts;
using LixoEletronico.Domain.Entities;
using LixoEletronico.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LixoEletronico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;
        private readonly IHttpContextAccessor _contextAccessor;

        public PersonController(ILogger<PersonController> logger, IPersonService personService, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _personService = personService;
            _contextAccessor = contextAccessor;
        }

        [HttpPost]
        public async Task<ActionResult> Add(PersonDto person)
        {
            await _personService.AddPerson(person);

            return NoContent();
        }

        [Route("info")]
        [HttpPost]
        public async Task<ActionResult> Get()
        {
            var user = _contextAccessor?.HttpContext?.User;
            int? id = int.Parse(user?.FindFirst(ClaimTypes.Sid)?.Value);

            if (id == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ResponseDto { Status = "Error", Message = "Usuário não encontrado!" });
            }

            PersonDto person = await _personService.GetPerson(id.Value);

            return Ok(person);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _personService.DeletePerson(id);

            return NoContent();
        }
    }
}
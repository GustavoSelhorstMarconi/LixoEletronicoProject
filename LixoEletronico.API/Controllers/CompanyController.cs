using LixoEletronico.Application.Contracts;
using LixoEletronico.Domain.Entities;
using LixoEletronico.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LixoEletronico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IHttpContextAccessor _contextAccessor;

        public CompanyController(ICompanyService companyService, IHttpContextAccessor contextAccessor)
        {
            _companyService = companyService;
            _contextAccessor = contextAccessor;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Add(CompanyDto company)
        {
            var user = _contextAccessor?.HttpContext?.User;
            company.RepresentantId = int.Parse(user?.FindFirst(ClaimTypes.Sid)?.Value);

            await _companyService.AddCompany(company);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update(int id, CompanyDto company)
        {
            await _companyService.UpdateCompany(id, company);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            CompanyDto company = await _companyService.GetCompany(id);

            return Ok(company);
        }

        [HttpPost("GetAll")]
        public async Task<ActionResult> GetAll(FilterCompanySearchDto filter)
        {
            List<CompanyDto> companies = await _companyService.GetAllCompanies(filter);

            return Ok(companies);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _companyService.DeleteCompany(id);

            return NoContent();
        }
    }
}

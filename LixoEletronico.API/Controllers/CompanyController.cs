using LixoEletronico.Application.Contracts;
using LixoEletronico.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LixoEletronico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        public async Task<ActionResult> Add(CompanyDto company)
        {
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

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<CompanyDto> companies = await _companyService.GetAllCompanies();

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

using LixoEletronico.Shared.Dtos;

namespace LixoEletronico.Application.Contracts
{
    public interface ICompanyService
    {
        Task AddCompany(CompanyDto companyDto);

        Task UpdateCompany(int id, CompanyDto companyDto);

        Task<CompanyDto> GetCompany(int id);

        Task<List<CompanyDto>> GetAllCompanies(FilterCompanySearchDto filter);

        Task DeleteCompany(int id);
    }
}

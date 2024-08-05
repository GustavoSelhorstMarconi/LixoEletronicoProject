using LixoEletronico.Domain.Entities;
using LixoEletronico.Shared.Dtos;

namespace LixoEletronico.Domain.Contracts
{
    public interface ICompanyRepository
    {
        Task UpdateCompany(int id, Company company);

        Task<Company> GetCompany(int id);

        Task<List<CompanyDto>> GetAllCompanies(FilterCompanySearchDto filter);
    }
}

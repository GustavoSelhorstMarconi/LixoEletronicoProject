using LixoEletronico.Domain.Entities;

namespace LixoEletronico.Application.Contracts
{
    public interface ICompanyService
    {
        Task AddCompany(Company company);

        Task UpdateCompany(int id, Company company);

        Task<Company> GetCompany(int id);

        Task DeleteCompany(int id);
    }
}

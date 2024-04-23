using LixoEletronico.Domain.Entities;

namespace LixoEletronico.Domain.Contracts
{
    public interface ICompanyRepository
    {
        Task UpdateCompany(int id, Company company);

        Task<Company> GetCompany(int id);

        Task<List<Company>> GetAllCompanies();
    }
}

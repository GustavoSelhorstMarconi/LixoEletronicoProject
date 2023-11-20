using LixoEletronico.Application.Dtos;
using LixoEletronico.Domain.Entities;

namespace LixoEletronico.Application.Contracts
{
    public interface ICompanyService
    {
        Task AddCompany(CompanyDto companyDto);

        Task UpdateCompany(int id, CompanyDto companyDto);

        Task<CompanyDto> GetCompany(int id);

        Task DeleteCompany(int id);
    }
}

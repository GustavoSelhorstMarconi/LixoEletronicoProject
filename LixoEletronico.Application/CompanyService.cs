using LixoEletronico.Application.Contracts;
using LixoEletronico.Domain.Contracts;
using LixoEletronico.Domain.Entities;

namespace LixoEletronico.Application
{
    public class CompanyService : ICompanyService
    {
        private readonly IGeneralRepository _generalRepository;
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(IGeneralRepository generalRepository, ICompanyRepository companyRepository)
        {
            _generalRepository = generalRepository;
            _companyRepository = companyRepository;
        }

        public async Task AddCompany(Company company)
        {
            await _generalRepository.Add(company);
        }

        public async Task UpdateCompany(int id, Company company)
        {
            await _companyRepository.UpdateCompany(id, company);
        }

        public Task<Company> GetCompany(int id)
        {
            return _companyRepository.GetCompany(id);
        }

        public async Task DeleteCompany(int id)
        {
            Company company = await _companyRepository.GetCompany(id);

            await _generalRepository.Delete(company);
        }
    }
}

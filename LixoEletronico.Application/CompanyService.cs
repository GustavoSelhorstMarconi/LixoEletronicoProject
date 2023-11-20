using AutoMapper;
using LixoEletronico.Application.Contracts;
using LixoEletronico.Application.Dtos;
using LixoEletronico.Domain.Contracts;
using LixoEletronico.Domain.Entities;

namespace LixoEletronico.Application
{
    public class CompanyService : ICompanyService
    {
        private readonly IGeneralRepository _generalRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(IGeneralRepository generalRepository, ICompanyRepository companyRepository, IMapper mapper)
        {
            _generalRepository = generalRepository;
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task AddCompany(CompanyDto companyDto)
        {
            var company = _mapper.Map<Company>(companyDto);

            await _generalRepository.Add(company);
        }

        public async Task UpdateCompany(int id, CompanyDto companyDto)
        {
            var company = _mapper.Map<Company>(companyDto);

            await _companyRepository.UpdateCompany(id, company);
        }

        public async Task<CompanyDto> GetCompany(int id)
        {
            var company = await _companyRepository.GetCompany(id);
            var companyDto = _mapper.Map<CompanyDto>(company);

            return companyDto;
        }

        public async Task DeleteCompany(int id)
        {
            Company company = await _companyRepository.GetCompany(id);

            await _generalRepository.Delete(company);
        }
    }
}

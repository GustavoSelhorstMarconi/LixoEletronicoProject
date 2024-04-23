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
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public CompanyService(IGeneralRepository generalRepository, ICompanyRepository companyRepository, IReviewRepository reviewRepository, IMapper mapper)
        {
            _generalRepository = generalRepository;
            _companyRepository = companyRepository;
            _reviewRepository = reviewRepository;
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

            companyDto.ReviewAverage = company.Reviews is null || !company.Reviews.Any() ?
                0 :
                company.Reviews.Sum(x => x.Rating) / company.Reviews.Count;

            return companyDto;
        }

        public async Task<List<CompanyDto>> GetAllCompanies()
        {
            var companies = await _companyRepository.GetAllCompanies();
            var reviews = await _reviewRepository.GetReviewsByCompanyId(companies.Select(x => x.Id).ToList());

            var companiesDto = _mapper.Map<List<CompanyDto>>(companies);

            companiesDto.All(x => {
                var companyReviews = reviews.Where(y => y.CompanyId == x.Id).ToList();

                x.ReviewAverage = !companyReviews.Any() ? 0 : companyReviews.Sum(x => x.Rating) / companyReviews.Count;

                return true;
            });

            return companiesDto;
        }

        public async Task DeleteCompany(int id)
        {
            Company company = await _companyRepository.GetCompany(id);

            await _generalRepository.Delete(company);
        }
    }
}

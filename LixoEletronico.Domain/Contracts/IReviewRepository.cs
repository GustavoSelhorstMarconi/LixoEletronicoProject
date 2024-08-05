using LixoEletronico.Domain.Entities;

namespace LixoEletronico.Domain.Contracts
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetReviewsByCompaniesIds(List<int> idsCompanies);

        Task<IEnumerable<Review>> GetReviewsByCompany(int companyId);
    }
}

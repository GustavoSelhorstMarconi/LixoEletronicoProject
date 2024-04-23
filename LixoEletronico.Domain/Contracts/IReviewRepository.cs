using LixoEletronico.Domain.Entities;

namespace LixoEletronico.Domain.Contracts
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetReviewsByCompanyId(List<int> idsCompanies);
    }
}

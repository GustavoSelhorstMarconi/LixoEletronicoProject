using LixoEletronico.Shared.Dtos;

namespace LixoEletronico.Application.Contracts
{
    public interface IReviewService
    {
        Task AddReview(ReviewDto review);

        Task<IEnumerable<ReviewDto>> GetReviewsByCompany(int companyId);
    }
}

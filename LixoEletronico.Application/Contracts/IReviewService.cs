using LixoEletronico.Application.Dtos;

namespace LixoEletronico.Application.Contracts
{
    public interface IReviewService
    {
        Task AddReview(ReviewDto review);
    }
}

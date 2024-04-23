using AutoMapper;
using LixoEletronico.Application.Contracts;
using LixoEletronico.Application.Dtos;
using LixoEletronico.Domain.Contracts;
using LixoEletronico.Domain.Entities;

namespace LixoEletronico.Application
{
    public class ReviewService : IReviewService
    {
        private readonly IGeneralRepository _generalRepository;
        private readonly IMapper _mapper;

        public ReviewService(IGeneralRepository generalRepository, IMapper mapper)
        {
            _generalRepository = generalRepository;
            _mapper = mapper;
        }

        public async Task AddReview(ReviewDto review)
        {
            Review reviewToAdd = _mapper.Map<Review>(review);

            await _generalRepository.Add(reviewToAdd);
        }
    }
}

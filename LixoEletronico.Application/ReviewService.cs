using AutoMapper;
using LixoEletronico.Application.Contracts;
using LixoEletronico.Shared.Dtos;
using LixoEletronico.Domain.Contracts;
using LixoEletronico.Domain.Entities;
using LixoEletronico.Application.Helpers;

namespace LixoEletronico.Application
{
    public class ReviewService : IReviewService
    {
        private readonly IGeneralRepository _generalRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewService(IGeneralRepository generalRepository, IReviewRepository reviewRepository, IMapper mapper)
        {
            _generalRepository = generalRepository;
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task AddReview(ReviewDto review)
        {
            Review reviewToAdd = _mapper.MapToReview(review);

            await _generalRepository.Add(reviewToAdd);
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsByCompany(int companyId)
        {
            IEnumerable<Review> reviews = await _reviewRepository.GetReviewsByCompany(companyId);

            List<ReviewDto> reviewsDto = _mapper.Map<List<ReviewDto>>(reviews);

            //List<ReviewDto> reviewsDto = _mapper.Map<List<ReviewDto>>(reviews, (x) =>
            //{
            //    x.AfterMap((src, dest) =>
            //    {
            //        ((List<Review>)src).ForEach(a =>
            //        {
            //            dest.Find(l => l.Id == a.Id).PersonName = a.Person.Name;
            //        });
            //    });
            //});

            return reviewsDto;
        }
    }
}

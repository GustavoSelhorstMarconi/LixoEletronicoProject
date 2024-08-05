using AutoMapper;
using LixoEletronico.Domain.Entities;
using LixoEletronico.Shared.Dtos;

namespace LixoEletronico.Application.Helpers
{
    public static class MapExtension
    {
        public static Review MapToReview(this IMapper mapper, ReviewDto reviewDto)
        {
            Review newReview = new Review(reviewDto.Rating, reviewDto.Comment, reviewDto.PersonId, reviewDto.CompanyId);

            return newReview;
        }
    }
}

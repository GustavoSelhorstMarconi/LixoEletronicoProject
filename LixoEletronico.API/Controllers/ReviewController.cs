using LixoEletronico.Application.Contracts;
using LixoEletronico.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LixoEletronico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IHttpContextAccessor _contextAccessor;

        public ReviewController(IReviewService reviewService, IHttpContextAccessor contextAccessor)
        {
            _reviewService = reviewService;
            _contextAccessor = contextAccessor;
        }

        [HttpPost]
        public async Task<ActionResult> Add(ReviewDto review)
        {
            var user = _contextAccessor?.HttpContext?.User;
            review.PersonId = int.Parse(user?.FindFirst(ClaimTypes.Sid)?.Value);

            await _reviewService.AddReview(review);

            return NoContent();
        }

        [HttpGet("{companyId}")]
        public async Task<ActionResult> GetReviewsFromCompany(int companyId)
        {
            IEnumerable<ReviewDto> reviews = await _reviewService.GetReviewsByCompany(companyId);

            return Ok(reviews);
        }
    }
}

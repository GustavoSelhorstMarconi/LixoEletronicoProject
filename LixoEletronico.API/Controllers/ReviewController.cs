using LixoEletronico.Application.Contracts;
using LixoEletronico.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LixoEletronico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public async Task<ActionResult> Add(ReviewDto review)
        {
            await _reviewService.AddReview(review);

            return NoContent();
        }
    }
}

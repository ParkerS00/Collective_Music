using Microsoft.AspNetCore.Mvc;
using MusicApi.Data;
using MusicApi.FrontFacingData;
using MusicApi.Request;
using MusicApi.Services;

namespace MusicApi.Controllers;

[Route("[controller]")]
[ApiController]
public class ReviewController : Controller
{
    private readonly ILogger<ReviewController> logger;
    private readonly IReviewService<Review> reviewService;

    public ReviewController(ILogger<ReviewController> logger, IReviewService<Review> reviewService)
    {
        this.logger = logger;
        this.reviewService = reviewService;
    }

    [HttpPost("{reviewRequest}")]
    public async Task Post([FromBody] AddReviewRequest request)
    {
        var review = new Review()
        {
            Id = request.Id,
            ItemId = request.ItemId,
            CustomerId = request.CustomerId,
            ReviewDate = request.ReviewDate,
            ReviewText = request.ReviewText,
            Rating = request.Rating
        };

        await reviewService.Add(review);
   
    }

    [HttpGet("{itemId}")]
    public async Task<List<Review>> Get(int itemId)
    {
        return await reviewService.GetItemReviews(itemId);
    }

}

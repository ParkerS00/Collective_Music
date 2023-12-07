using Microsoft.AspNetCore.Mvc;

namespace MusicApi.Services;

public interface IReviewService<Review>
{
    Task<Review> Add(Review review);

    Task<List<Review>> GetItemReviews(int id);
}

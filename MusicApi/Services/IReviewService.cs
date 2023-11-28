using Microsoft.AspNetCore.Mvc;
using MusicBlazorApp.Data;

namespace MusicApi.Services;

public interface IReviewService<Review>
{
    Task<Review> Add(Review review);
}

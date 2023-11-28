using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicBlazorApp.Data;

namespace MusicApi.Services;

public class ReviewService : IReviewService<Review>
{
    private readonly ILogger<ReviewService> logger;
    private IDbContextFactory<MusicDbContext> contextFactory;

    public ReviewService(ILogger<ReviewService> logger, IDbContextFactory<MusicDbContext> context)
    {
        this.logger = logger;
        this.contextFactory = context;
    }
    public async Task<Review> Add(Review review)
    {
        var context = contextFactory.CreateDbContext();
        context.Reviews.Add(review);
        await context.SaveChangesAsync();
        return review;
    }

}

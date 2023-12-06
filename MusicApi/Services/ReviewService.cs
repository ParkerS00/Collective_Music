using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApi.Data;

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

    public ReviewService()
    {
        
    }
    public async Task<Review> Add(Review review)
    {
        return await SaveToDatabase(review);
    }

    public virtual async Task<Review> SaveToDatabase(Review review)
    {
        var context = contextFactory.CreateDbContext();
        context.Reviews.Add(review);
        await context.SaveChangesAsync();
        return review;
    }

}

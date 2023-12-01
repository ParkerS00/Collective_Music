using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApi.Data;

namespace MusicApi.Services;

public class RoomService : IRoomService
{
    private readonly ILogger<RoomService> logger;
    private IDbContextFactory<MusicDbContext> contextFactory;

    public RoomService(ILogger<RoomService> logger, IDbContextFactory<MusicDbContext> context)
    {
        this.logger = logger;
        this.contextFactory = context;
    }

    public async Task<IEnumerable<Room>> Get()
    {
        var context = contextFactory.CreateDbContext();
        return await context.Rooms
            .Include(r => r.RoomRentals)
            .Include(r => r.RoomType)
            .ToListAsync();
    }
}

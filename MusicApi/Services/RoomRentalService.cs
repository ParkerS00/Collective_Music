using Microsoft.EntityFrameworkCore;
using MusicApi.Data;

namespace MusicApi.Services
{
    public class RoomRentalService : IRoomRentalService
    {
        private readonly ILogger<RoomRentalService> logger;
        private IDbContextFactory<MusicDbContext> contextFactory;
        public RoomRentalService(ILogger<RoomRentalService> logger, IDbContextFactory<MusicDbContext> contextFactory) 
        {
            this.logger = logger;
            this.contextFactory = contextFactory;
        }

        public async Task<IEnumerable<RoomRental>> GetAll()
        {
            var context = contextFactory.CreateDbContext();
            return await context.RoomRentals
                .Include(r => r.Room)
                .ToListAsync();
        }
    }
}

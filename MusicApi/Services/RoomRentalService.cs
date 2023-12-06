using Microsoft.EntityFrameworkCore;
using MusicApi.Data;

namespace MusicApi.Services;

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

    public async Task<RoomRental?> Add(RoomRental roomRental, string email)
    {
        var context = contextFactory.CreateDbContext();

        var customer = context.Customers.Where(x => x.Email == email).FirstOrDefault();
        if(customer == default(Customer) )
        {
            return null;
        }
        var rental = new Rental()
        {
            RentalDate = DateOnly.FromDateTime(DateTime.Now),
            CustomerId = customer.Id,
            //EmployeeId = 3
        };

        context.Rentals.Add(rental);
        await context.SaveChangesAsync();

        roomRental.RentalId = rental.Id;

        context.RoomRentals.Add(roomRental);
        await context.SaveChangesAsync();
        return roomRental;
    }
}

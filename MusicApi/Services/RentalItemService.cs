using Microsoft.EntityFrameworkCore;
using MusicApi.Data;

namespace MusicApi.Services;

public class RentalItemService
{
    private readonly ILogger<RentalItemService> logger;
    private IDbContextFactory<MusicDbContext> contextFactory;

    public RentalItemService(ILogger<RentalItemService> logger, IDbContextFactory<MusicDbContext> contextFactory)
    {
        this.logger = logger;
        this.contextFactory = contextFactory;
    }

    public async Task<IEnumerable<ItemRental>> GetAll()
    {
        var context = contextFactory.CreateDbContext();
        return await context.ItemRentals
            .Include(i => i.Inventory)
            .ToListAsync();
    }

    public async Task<ItemRental?> Add(ItemRental itemRental, string email)
    {
        var context = contextFactory.CreateDbContext();

        var customer = context.Customers.Where(x => x.Email == email).FirstOrDefault();
        if (customer == default(Customer)) 
        {
            return null;
        }
        var rental = new Rental()
        {
            RentalDate = DateOnly.FromDateTime(DateTime.Now),
            CustomerId = customer.Id
        };

        context.Rentals.Add(rental);
        await context.SaveChangesAsync();

        itemRental.RentalId = rental.Id;

        context.ItemRentals.Add(itemRental);
        await context.SaveChangesAsync();
        return itemRental;
    }
}

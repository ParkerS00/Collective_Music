using Microsoft.EntityFrameworkCore;
using MusicApi.Data;
using MusicApi.Request;

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

    public async Task<ItemRental?> Add(AddItemRentalRequest request)
    {
        var context = contextFactory.CreateDbContext();

        var inventoryItem = await context.Inventories
            .Include(i => i.CartItem)
            .Where(i => i.IsRentable == true)
            .Where(i => i.IsPurchased == false)
            .Where(i => i.CartItem == null)
            .Where(i => i.ItemId == request.ItemId)
            .FirstOrDefaultAsync(); 

        var customer = context.Customers.Where(x => x.Email == request.UserEmail).FirstOrDefault();
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

        var itemRental = new ItemRental()
        {
            FinalRentalPrice = request.FinalRentalPrice,
            RentalId = rental.Id,
            InventoryId = inventoryItem.Id
        };

        context.ItemRentals.Add(itemRental);
        await context.SaveChangesAsync();
        return itemRental;
    }
}

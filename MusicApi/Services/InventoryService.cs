using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MusicApi.Data;

namespace MusicApi.Services;

public class InventoryService : IInventoryService<Inventory>
{
    private readonly ILogger<InventoryService> logger;
    private IDbContextFactory<MusicDbContext> contextFactory;

    public InventoryService(ILogger<InventoryService> logger, IDbContextFactory<MusicDbContext> contextFactory)
    {
        this.logger = logger;
        this.contextFactory = contextFactory;
    } 

    public async Task<IEnumerable<Inventory>> GetAll()
    {
        var context = contextFactory.CreateDbContext(); 
        return await context.Inventories.ToListAsync();
    }

    public async Task<bool> Update(string email)
    {
        var context = contextFactory.CreateDbContext();
        var cartItems = await context.CartItems
            .Include(x => x.Customer)
            .Include(x => x.Inventory)
                .ThenInclude(x => x.Item)
            .Where(x => x.Customer.Email == email)
            .ToListAsync();

        var customer = context.Customers.Where(x => x.Email == email).FirstOrDefault();
        if (customer == default(Customer))
        {
            return false ;
        }

        var purchase = new Purchase()
        {
            PurchaseDate = DateOnly.FromDateTime(DateTime.Now),
            CustomerId = customer.Id,
        };

        context.Purchases.Add(purchase);
        await context.SaveChangesAsync();


        foreach (var cuc in cartItems)
        {
            /*if (cuc.Inventory.IsPurchased == true)
            {
                return false;
            }*/
            cuc.Inventory.IsPurchased = true;
            context.Inventories.Update(cuc.Inventory);
            var piuc = new PurchaseItem()
            {
                PurchaseId = purchase.Id,
                InventoryId = (int)cuc.InventoryId,
                FinalPrice = cuc.Inventory.Item.SellPrice
            };
            customer.RewardPoints += (int)cuc.Inventory.Item.SellPrice; 
            context.PurchaseItems.Add(piuc);
            context.CartItems.Remove(cuc);
        }

        context.Customers.Update(customer);

        await context.SaveChangesAsync();

        return true;
    }
}

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
            .Where(x => x.Customer.Email == email)
            .ToListAsync();

        foreach (var cuc in cartItems)
        {
            /*if (cuc.Inventory.IsPurchased == true)
            {
                return false;
            }*/
            cuc.Inventory.IsPurchased = true;
            context.Inventories.Update(cuc.Inventory);

            context.CartItems.Remove(cuc);
        }

        await context.SaveChangesAsync();

        return true;
    }
}

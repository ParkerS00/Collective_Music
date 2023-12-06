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

    public async Task<Inventory> Update(Inventory inventory)
    {
        var context = contextFactory.CreateDbContext();
        var iuc = await context.Inventories.Where(i => i.ItemId == inventory.ItemId).FirstOrDefaultAsync();

        iuc.ItemId = inventory.ItemId;
        iuc.StatusId = inventory.StatusId;
        iuc.IsRentable = inventory.IsRentable;
        iuc.IsPurchased = inventory.IsPurchased;

        context.Inventories.Update(iuc);
        await context.SaveChangesAsync();

        return iuc;
    }
}

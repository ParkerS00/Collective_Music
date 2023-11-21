using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicBlazorApp.Data;

namespace MusicApi.Services;

public class ItemService : IItemService<Item>
{
    private readonly ILogger<ItemService> logger;
    private IDbContextFactory<MusicDbContext> contextFactory;

    public ItemService(ILogger<ItemService> logger, IDbContextFactory<MusicDbContext> context)
    {
        this.logger = logger;
        this.contextFactory = context;
    }

    public async Task<Item> Get(int id)
    {
        var context = contextFactory.CreateDbContext();
        return await context.Items
            .Include(i => i.ItemStatuses)
                .ThenInclude(iStat => iStat.Status)
            .Include(c => c.ItemCategories)
                .ThenInclude(c => c.Category)
            .Include(i => i.ItemImages)
            .Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Item>> GetAll()
    {
        var context = contextFactory.CreateDbContext();
        return await context.Items
            .Include(i => i.ItemStatuses)
            .ThenInclude(itemStat => itemStat.Status)
            .Include(i => i.ItemCategories)
                .ThenInclude(ic => ic.Category)
            .Include(i => i.ItemImages)
            .ToListAsync();
    }

    public async Task<Item> Add(Item item)
    {
        throw new NotImplementedException();
    }

    public Task<Item> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Item> Update(Item item)
    {
        throw new NotImplementedException();
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicBlazorApp.Data;

namespace MusicApi.Services;

public class ItemService : I_ItemService<Item>
{
    private readonly ILogger<ItemService> logger;
    private IDbContextFactory<MusicDBContext> contextFactory;

    public ItemService(ILogger<ItemService> logger, IDbContextFactory<MusicDBContext> context)
    {
        this.logger = logger;
        this.contextFactory = context;
    }

    public async Task<Item> Get(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Item>> GetAll()
    {
        var context = contextFactory.CreateDbContext();
        return await context.Items
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

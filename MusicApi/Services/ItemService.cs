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
            .Include(i => i.Reviews)
                .ThenInclude(r => r.Customer)
            .Include(s => s.ItemStatuses)
            .Where(i => i.Id == id)
            .FirstOrDefaultAsync();
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
            //.Include(r => r.Reviews)
            //     .ThenInclude(r => r.Customer)
            .ToListAsync();
    }

    public async Task<Item> Add(Item item)
    {
        Item item1 = new Item()
        {
            ItemName = item.ItemName,
            Description = item.Description,
            SellPrice = item.SellPrice,
            SuggestedRentalPrice = item.SuggestedRentalPrice,
            SerialNumber = item.SerialNumber,

        };
        var context = contextFactory.CreateDbContext();
        context.Items.Add(item1);
        //string connection = context.Database.GetConnectionString();
        await context.SaveChangesAsync();

        return item1;
    }

    public Task<Item> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Item> Update(Item item)
    {
        //Get item from db
        var context = contextFactory.CreateDbContext();
        var ruc = await context.Items.Where(i => i.Id == item.Id).FirstOrDefaultAsync();

        //alter item from db
        ruc.ItemName = item.ItemName;
        ruc.Description = item.Description;
        ruc.SellPrice = item.SellPrice;
        ruc.SuggestedRentalPrice = item.SuggestedRentalPrice;

        //Put back in the database
        context.Items.Update(ruc);
        await context.SaveChangesAsync();

        return ruc;
    }

    public async Task AddImageFilePath(string filePath, int itemId, bool isPrimary)
    {
        //TODO: Change all the previous true images to false
        var context = contextFactory.CreateDbContext();

        var newItemImage = new ItemImage()
        {
            ItemId = itemId,
            Filepath = filePath,
            IsPrimary = isPrimary
        };

        await context.ItemImages.AddAsync(newItemImage);
        await context.SaveChangesAsync();
    }

    public async Task RemovePrimaries(int id)
    {
        var context = contextFactory.CreateDbContext();

        var Primaries = await context.ItemImages
                                .Where(i => i.ItemId == id)
                                .Where(i => i.IsPrimary == true) 
                                .ToListAsync();

        foreach (var primary in Primaries) 
        {
            primary.IsPrimary = false;
            context.ItemImages.Update(primary);
        }

        await context.SaveChangesAsync();
    }
}

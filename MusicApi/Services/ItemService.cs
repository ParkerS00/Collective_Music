using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApi.Data;

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

    public ItemService()
    {
        
    }

    public async Task<Item?> Get(int id)
    {
        if(id < 0)
        {
            return null;
        }
        return await GetFromDatabase(id);
    }

    public virtual async Task<Item?> GetFromDatabase(int id)
    {
        var context = contextFactory.CreateDbContext();
        return await context.Items
            .Include(i => i.Inventories)
            .ThenInclude(iStat => iStat.Status)
            .Include(i => i.Inventories)
            .ThenInclude(inv => inv.CartItem)
            .Include(c => c.ItemCategories)
            .ThenInclude(c => c.Category)
            .Include(i => i.ItemImages)
            .Include(i => i.Reviews)
            .ThenInclude(r => r.Customer)
            .Where(i => i.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Item>> GetAll()
    {
        var context = contextFactory.CreateDbContext();
        return await context.Items
            .Include(i => i.Inventories)
                .ThenInclude(itemStat => itemStat.Status)
            .Include(i => i.ItemCategories)
                .ThenInclude(ic => ic.Category)
            .Include(i => i.ItemImages)
            .Include(r => r.Reviews)
                 .ThenInclude(r => r.Customer)
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

    public async Task AttemptAddImageFilePath(string filePath, int itemId, bool isPrimary)
    {
        var newItemImage = new ItemImage()
        {
            ItemId = itemId,
            Filepath = filePath,
            IsPrimary = isPrimary
        };
        if (!newItemImage.VerifyPath())
        {
            return;
        }
        await AddImageFilePath(newItemImage);
       
    }

    public virtual async Task AddImageFilePath(ItemImage itemImage)
    {
        var context = contextFactory.CreateDbContext();


        await context.ItemImages.AddAsync(itemImage);
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

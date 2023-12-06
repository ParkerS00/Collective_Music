using Microsoft.EntityFrameworkCore;
using MusicApi.Data;

namespace MusicApi.Services;

public class PurchaseItemService
{
    private readonly ILogger<PurchaseItemService> logger;
    private IDbContextFactory<MusicDbContext> contextFactory;

    public PurchaseItemService(ILogger<PurchaseItemService> logger, IDbContextFactory<MusicDbContext> contextFactory)
    {
        this.logger = logger;
        this.contextFactory = contextFactory;
    }

    public async Task<IEnumerable<PurchaseItem>> GetAll()
    {
        var context = contextFactory.CreateDbContext();
        return await context.PurchaseItems
            .Include(p => p.Purchase)
            .Include(p => p.Inventory)
            .ToListAsync();
    }

    public async Task<PurchaseItem?> Add(PurchaseItem purchaseItem, string email)
    {
        var context = contextFactory.CreateDbContext();

        var customer = context.Customers.Where(x => x.Email == email).FirstOrDefault();
        if(customer == default(Customer))
        {
            return null;
        }
        var purchase = new Purchase()
        {
            PurchaseDate = DateOnly.FromDateTime(DateTime.Now),
            CustomerId = customer.Id,
        };

        context.Purchases.Add(purchase);
        await context.SaveChangesAsync();

        purchaseItem.PurchaseId = purchase.Id;

        context.PurchaseItems.Add(purchaseItem);
        await context.SaveChangesAsync();
        return purchaseItem;
    }
}

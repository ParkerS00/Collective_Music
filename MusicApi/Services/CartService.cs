using Microsoft.EntityFrameworkCore;
using MusicApi.Data;
using MusicApi.Request;

namespace MusicApi.Services;

public class CartService
{

    private readonly ILogger<CartService> logger;
    private IDbContextFactory<MusicDbContext> contextFactory;

    public CartService(ILogger<CartService> logger, IDbContextFactory<MusicDbContext> contextFactory)
    {
        this.logger = logger;
        this.contextFactory = contextFactory;
    }

    public async Task<bool> Add(AddItemToCartRequest request)
    {
        var context = contextFactory.CreateDbContext();

        List<Inventory> invItems = await context.Inventories
            .Include(i => i.Status)
            .Include(i => i.CartItem)
            .Where(i => i.ItemId == request.ItemId && i.Status.StatusName == request.StatusName && i.CartItem == null)
            .ToListAsync();

        int customerId = await context.Customers
            .Where(c => c.Email == request.userEmail)
            .Select(c => c.Id)
            .FirstOrDefaultAsync();

        if(invItems.Count < request.Quantity || customerId == 0) 
        {
            return false;
        }

        
        for(int i = 0; i < request.Quantity; i++)
        {
            var newCartItem = new CartItem()
            {
                CustomerId = customerId,
                InventoryId = invItems[i].Id,
            };
            context.CartItems.Add(newCartItem);
        }

        await context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Inventory>> GetCartItems(string userEmail)
    {
        var context = contextFactory.CreateDbContext();

        var selection = await context.Inventories
            .Include(i => i.Status)
            .Include(i => i.Item)
             .ThenInclude(i => i.ItemImages)
            .Include(i => i.CartItem)
                .ThenInclude(ct => ct.Customer)
            .Where(i => i.CartItem.Customer.Email == userEmail)
            .ToListAsync();

        return selection;
    }
}

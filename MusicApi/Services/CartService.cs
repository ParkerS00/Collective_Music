﻿using Microsoft.EntityFrameworkCore;
using MusicApi.Data;
using MusicApi.Dtos;
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
            .Where(i => i.ItemId == request.ItemId && i.Status.StatusName == request.StatusName && i.CartItem == null && i.IsPurchased != true)
            .ToListAsync();

        int customerId = await context.Customers
            .Where(c => c.Email == request.userEmail)
            .Select(c => c.Id)
            .FirstOrDefaultAsync();

        if(invItems.Count < request.Quantity - 1 || customerId == 0) 
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

    public async Task DeleteItem(string email, int itemId, int quantity)
    {
        var context = contextFactory.CreateDbContext();

        var selection = await context.Inventories
            .Include(i => i.Status)
            .Include(i => i.Item)
             .ThenInclude(i => i.ItemImages)
            .Include(i => i.CartItem)
                .ThenInclude(ct => ct.Customer)
            .Where(i => i.CartItem.Customer.Email == email)
            .Where(i => i.ItemId == itemId)
            .ToListAsync();

        if(quantity > selection.Count()) 
        {
            return;
        }

        foreach( var item in selection )
        {
            context.Inventories.Remove(item);
        }
        await context.SaveChangesAsync();
    }

    public async Task DeleteItem(int customerId, int itemId, string status)
    {
        var context = contextFactory.CreateDbContext();

        var selection = await context.CartItems
            .Include(i => i.Customer)
            .Include(i => i.Inventory)
                .ThenInclude(i => i.Item)
            .Include(i => i.Inventory.Status)
            .Where(i => i.Inventory.Item.Id == itemId && i.Inventory.Status.StatusName == status)
            .ToListAsync();

        foreach (var item in selection)
        {
            context.CartItems.Remove(item);
        }
        await context.SaveChangesAsync();
    }
}

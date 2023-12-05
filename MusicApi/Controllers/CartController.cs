using Microsoft.AspNetCore.Mvc;
using MusicApi.Data;
using MusicApi.Dtos;
using MusicApi.Request;
using MusicApi.Services;

namespace MusicApi.Controllers;

[Route("[controller]")]
[ApiController]
public class CartController : Controller
{
    private CartService cartService { get; set; }

    public CartController(CartService cartService)
    {
        this.cartService = cartService;
    }


    [HttpPost("{request}")]
    public async Task Post([FromBody] AddItemToCartRequest request)
    {
        await cartService.Add(request);
    }

    [HttpGet("{email}")]
    public async Task<IEnumerable<CartItemDto>> Get(string email)
    {
        var cartItems = await cartService.GetCartItems(email);

        var quantities = cartItems.GroupBy(c => new { c.ItemId, c.StatusId }).Select(c => c.Count());

        List<CartItemDto> cartItemDtos = new List<CartItemDto>();
        var inventoryItems = cartItems.GroupBy(c => new { c.ItemId, c.StatusId }).ToList();
        if(inventoryItems is null) 
        {
            return new List<CartItemDto>();
        }

        int count = 0;
        foreach(var sum in quantities)
        {
            cartItemDtos.Add(new CartItemDto()
            {
                Quantity = sum,
                StatusName = inventoryItems.ElementAt(count).First().Status.StatusName,
                Item = inventoryItems.ElementAt(count).First().Item.ToItemDto()
            });
            count++;
        }

        return cartItemDtos;
    }

    //[HttpDelete("{email}/{id}/{quantity}")]
    //public async Task Delete(string email, int id, int quantity)
    //{
    //    await cartService.DeleteItem(email, id, quantity);
    //}

    [HttpDelete("{customerId}/{itemId}/{status}")]
    public async Task DeleteWholeItem(int customerId, int itemId, string status)
    {
        await cartService.DeleteItem(customerId, itemId, status);
    }
}

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

        var quantity = cartItems.GroupBy(c => c.ItemId).Select(c => c.Count());


        int count = 0;
        List<CartItemDto> cartItemDtos = new List<CartItemDto>();
        var inventoryItems = cartItems.GroupBy(c => c.ItemId).FirstOrDefault();
        if(inventoryItems is null) 
        {
            return new List<CartItemDto>();
        }
        foreach (var cartItem in inventoryItems) 
        {
            cartItemDtos.Add(new CartItemDto()
            {
                Quantity = quantity.ElementAt(count),
                StatusName = cartItem.Status.StatusName,
                Item = cartItem.Item.ToItemDto(),

            });
            count++;
        }

        return cartItemDtos;
    }
}

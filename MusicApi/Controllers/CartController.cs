using Microsoft.AspNetCore.Mvc;
using MusicApi.Data;
using MusicApi.Request;
using MusicApi.Services;

namespace MusicApi.Controllers;

[Route("[controller]")]
[ApiController]
public class CartController : Controller
{
    private CartService cartService { get; set; }

    [HttpPost("{request}")]
    public async Task Post([FromBody] AddItemToCartRequest request)
    {

        await cartService.Add(request);
    }
}

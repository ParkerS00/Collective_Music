using Microsoft.AspNetCore.Mvc;
using MusicApi.Data;
using MusicApi.Services;
using MusicBlazorApp.Data;

namespace MusicApi.Controllers;

[Route("[controller]")]
[ApiController]
//<div> json </div>
public class ItemsController : Controller
{
    private readonly ILogger<ItemsController> logger;
    private readonly IItemService<Item> itemService;

    public ItemsController(ILogger<ItemsController> logger, IItemService<Item> itemService)
    {
        this.logger = logger;
        this.itemService = itemService;
    }

    // enpoint "/items"
    [HttpGet()]
    public async Task<List<ItemDto>> Get()
    {
        IEnumerable<Item> items = await itemService.GetAll();
        List<ItemDto> itemDtos = new List<ItemDto>();
        foreach (var item in items)
        {
            itemDtos.Add(item.ToItemDto());
        }
        return itemDtos;
    }

    [HttpGet("{id}")]
    public async Task<ItemDto> Get(int id)
    {
        Item item = await itemService.Get(id);
        return new ItemDto(item);
    }
}

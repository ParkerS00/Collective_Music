using Microsoft.AspNetCore.Mvc;
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
    public async Task<IEnumerable<Item>> Get()
    {
        IEnumerable<Item> items = await itemService.GetAll();

        // TODO eventually add an itemDTO
        //var items = new List<Item>();

        //foreach(var item in iDb)
        //{
        //    items.Add(item);
        //}

        return items;
    }

    [HttpGet("{id}")]
    public async Task<Item> Get(int id)
    {
        Item item = await itemService.Get(id);
        return item;
    }
}

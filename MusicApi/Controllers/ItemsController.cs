using Microsoft.AspNetCore.Mvc;
using MusicApi.Data;
using MusicApi.Dtos;
using MusicApi.FrontFacingData;
using MusicApi.Services;
using System.Diagnostics.CodeAnalysis;

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

    [HttpPost("{itemRequest}")]
    public async Task Post([FromBody] AddItemRequest request)
    {
        var item = new Item()
        {
            //Id = request.Id,
            ItemName = request.ItemName,
            Description = request.ItemText,
            SellPrice = request.SellPrice,
            SuggestedRentalPrice = request.RentPrice,
            SerialNumber = request.SKU
        };
        if (request.Id > 0)
        {
            item.Id = request.Id;
            item = await itemService.Update(item);
        }
        else
        {
            item = await itemService.Add(item);
        }

     
        if (request.ImageFilePath is not null && request.ImageFilePath != "")
        {
            if(request.IsPrimary)
            {
                await itemService.RemovePrimaries(request.Id);
            }
            await itemService.AttemptAddImageFilePath(request.ImageFilePath, item.Id, request.IsPrimary);
        }
    }
}

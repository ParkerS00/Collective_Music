﻿using Microsoft.AspNetCore.Mvc;
using MusicApi.Services;
using MusicBlazorApp.Data;

namespace MusicApi.Controllers;

[Route("[controller]")]
[ApiController]
//<div> json </div>
public class ItemsController : Controller
{
    private readonly ILogger<ItemsController> logger;
    private readonly I_ItemService<Item> itemService;

    public ItemsController(ILogger<ItemsController> logger, I_ItemService<Item> itemService)
    {
        this.logger = logger;
        this.itemService = itemService;
    }

    // enpoint "/items"
    [HttpGet()]
    public async Task<IEnumerable<Item>> Get()
    {
        IEnumerable<Item> iDb = await itemService.GetAll();

        // TODO eventually add an itemDTO
        //var items = new List<Item>();

        //foreach(var item in iDb)
        //{
        //    items.Add(item);
        //}
        
        return iDb;
        
    }
   
}

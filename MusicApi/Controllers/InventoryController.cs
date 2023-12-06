using Microsoft.AspNetCore.Mvc;
using MusicApi.Data;
using MusicApi.Request;
using MusicApi.Services;
using System.Net.Http;
using System.Runtime.InteropServices;

[Route("[controller]")]
[ApiController]
public class InventoryController : Controller
{
    private readonly ILogger<InventoryController> logger;
    private readonly IInventoryService<Inventory> inventoryService;

    public InventoryController(ILogger<InventoryController> logger, IInventoryService<Inventory> inventoryService)
    {
        this.logger = logger;
        this.inventoryService = inventoryService;
    }

    [HttpPatch("{inventoryRequest}")]
    public async Task Update(AddInventoryRequest request)
    {
        var Inventory = new Inventory()
        {
            Id = request.Id,
            ItemId = request.ItemId,
            StatusId = request.StatusId,
            IsRentable = request.IsRentable,
            IsPurchased = request.IsPurchased,
        };

        await inventoryService.Update(Inventory);
    }
}

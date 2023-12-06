using Microsoft.AspNetCore.Mvc;
using MusicApi.Data;
using MusicApi.Request;
using MusicApi.Services;
using System.Runtime.InteropServices;

namespace MusicApi.Controllers;

[Route("[controller]")]
[ApiController]
public class PurchaseItemController : Controller
{
    private readonly ILogger<PurchaseItemController> logger;
    private PurchaseItemService purchaseItemService;

    public PurchaseItemController(ILogger<PurchaseItemController> logger, PurchaseItemService purchaseItemService)
    {
        this.logger = logger;
        this.purchaseItemService = purchaseItemService;
    }

    [HttpGet()]
    public async Task<IEnumerable<PurchaseItem>> Get()
    {
        return await purchaseItemService.GetAll();
    }
}

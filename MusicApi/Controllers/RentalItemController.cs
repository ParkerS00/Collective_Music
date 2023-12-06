using Microsoft.AspNetCore.Mvc;
using MusicApi.Data;
using MusicApi.Request;
using MusicApi.Services;

namespace MusicApi.Controllers;

[Route("[controller]")]
[ApiController]
public class RentalItemController : Controller
{
    private readonly ILogger<RentalItemController> logger;
    private RentalItemService rentalItemService;

    public RentalItemController(ILogger<RentalItemController> logger, RentalItemService rentalItemService)
    {
        this.logger = logger;
        this.rentalItemService = rentalItemService;
    }

    [HttpGet()]
    public async Task<IEnumerable<ItemRental>> Get()
    {
        return await rentalItemService.GetAll();
    }

    [HttpPost("{request}")]
    public async Task Post([FromBody] AddItemRentalRequest request)
    {
        var itemRental = new ItemRental()
        {
            InventoryId = request.InventoryId,
            FinalRentalPrice = request.FinalRentalPrice,
            OutCondition = request.OutCondition,
        };

        await rentalItemService.Add(itemRental, request.UserEmail);
    }
}

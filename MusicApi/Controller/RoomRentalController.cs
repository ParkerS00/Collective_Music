using Microsoft.AspNetCore.Mvc;
using MusicApi.Services;
using MusicBlazorApp.Data;

namespace MusicApi.Controllers;

[Route("[controller]")]
[ApiController]
public class RoomRentalController : Controller
{
    private readonly ILogger<RoomRentalController> logger;
    private IRoomRentalService roomRentalService;
    public RoomRentalController(ILogger<RoomRentalController> logger, IRoomRentalService roomRentalService)
    {
        this.logger = logger;
        this.roomRentalService = roomRentalService;
    }

    [HttpGet()]
    public async Task<IEnumerable<RoomRental>> Get()
    {
        return await roomRentalService.GetAll();
    }

    //[HttPost("{email}/{start}/")
    //return id

    //CustomerID - from user email
    //RentalStart date - Current date
    //RentalID - database
    //RoomID - Get the chosen rooms id
    //ActualPrice - Should just be the suggest
    //StartTime - Whatever chosen
}

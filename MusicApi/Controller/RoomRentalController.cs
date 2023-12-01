using Microsoft.AspNetCore.Mvc;
using MusicApi.Data;
using MusicApi.Services;

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
}

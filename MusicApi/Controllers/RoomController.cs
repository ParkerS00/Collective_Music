using Microsoft.AspNetCore.Mvc;
using MusicApi.Dtos;
using MusicApi.Services;


[Route("[controller]")]
[ApiController]
public class RoomController : Controller
{
    private readonly ILogger<RoomController> logger;
    private IRoomService roomService;

    public RoomController(ILogger<RoomController> logger, IRoomService roomService)
    {
        this.logger = logger;
        this.roomService = roomService;
    }

    [HttpGet("{month}/{day}/{year}")]
    public async Task<IEnumerable<RoomDto>> Get(int month, int day, int year)
    {
        IEnumerable<RoomDto> room = (await roomService.Get()).Select(r => new RoomDto(r, new DateOnly(year, month, day)));
        return room;
    }

}

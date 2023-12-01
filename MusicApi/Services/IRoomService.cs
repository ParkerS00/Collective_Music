using Microsoft.AspNetCore.Mvc;
using MusicApi.Data;

namespace MusicApi.Services;

public interface IRoomService
{
    Task<IEnumerable<Room>> Get();
}

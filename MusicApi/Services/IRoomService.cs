using Microsoft.AspNetCore.Mvc;
using MusicBlazorApp.Data;

namespace MusicApi.Services;

public interface IRoomService
{
    Task<IEnumerable<Room>> Get();
}

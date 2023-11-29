using MusicApi.Data;
using MusicBlazorApp.Data;

namespace MusicApi.Services;

public interface IRoomRentalService
{
    Task<IEnumerable<RoomRental>> GetAll();
}

using MusicApi.Data;

namespace MusicApi.Services;

public interface IRoomRentalService
{
    Task<IEnumerable<RoomRental>> GetAll();
}

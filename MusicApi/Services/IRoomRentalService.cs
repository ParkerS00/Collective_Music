using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using MusicApi.Data;

namespace MusicApi.Services;

public interface IRoomRentalService
{

    Task<RoomRental> Add(RoomRental roomRental, string email);
}

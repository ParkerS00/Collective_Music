using MusicBlazorApp.Data;

namespace MusicApi.Data;

public class RoomRentalDto
{
    public decimal? ActualPrice { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

}

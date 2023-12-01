using MusicBlazorApp.Data;

namespace MusicApi.Data;

public class RoomDto
{
    public int Id { get; set; }
    public string RoomName { get; set; }

    public int MaxCapacity { get; set; }

    public string RoomTypeName { get; set; }

    public decimal RoomPrice { get; set; }

    public IEnumerable<TimeAvailability> TimeFrames { get; set; }

    public RoomDto(Room room, DateOnly date)
    {
        var rentalsFromDate = room.RoomRentals.Where(rr => (DateOnly.FromDateTime((DateTime)rr.StartTime)) == date);
        List<TimeAvailability> timeAvailability = new List<TimeAvailability>();
        //i = opring time
        //22 is close
        //+2 is time intervals they can choose
        var TimeIncrement = 2;
        for (int i = 8; i < 22; i += TimeIncrement)
        {
            timeAvailability.Add(new TimeAvailability(new DateTime(date.Year, date.Month, date.Day, i, 0, 0), new DateTime(date.Year, date.Month, date.Day, i+TimeIncrement, 0, 0), true));
        }
        if (rentalsFromDate is not null)
        {
            foreach(var rental in  rentalsFromDate)
            {
                var takenTime = timeAvailability.Where(t => t.startTime == rental.StartTime).First();
                timeAvailability.Remove( takenTime );
                takenTime.isAvailable = false;
                timeAvailability.Add(takenTime);
            }
            
        }
        Id = room.Id;
        TimeFrames = timeAvailability;
        RoomName = room.RoomName;
        MaxCapacity = (int)room.MaxCapacity;
        RoomTypeName = room.RoomType.RoomTypeName;
        RoomPrice = (decimal)room.RoomType.BasePrice;
    }

    public RoomDto()
    {
        
    }
}

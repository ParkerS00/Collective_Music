namespace MusicApi.Data;

public class TimeAvailability
{
    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }
    public bool isAvailable { get; set; }

    public TimeAvailability()
    {
        
    }
    public TimeAvailability(DateTime startTime, DateTime endTime, bool isAvailable)
    {
        this.startTime = startTime;
        this.endTime = endTime;
        this.isAvailable = isAvailable;
    }
}

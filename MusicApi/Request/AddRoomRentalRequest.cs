namespace MusicApi.Request
{
    public class AddRoomRentalRequest
    {
        public string? userEmail { get; set; }
        public int? Id { get; set; }
        public int? RoomId { get; set; }
        public decimal? ActualPrice { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public AddRoomRentalRequest()
        {

        }

        public AddRoomRentalRequest(string email, int roomId, decimal actualPrice, DateTime startTime, DateTime endTime)
        {
            RoomId = roomId;
            ActualPrice = actualPrice;
            StartTime = startTime;
            EndTime = endTime;
            userEmail = email;
        }
    }
}

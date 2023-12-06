namespace MusicApi.Request
{
    public class AddInventoryRequest
    {
        public int Id { get; set; }
        public int? ItemId { get; set; } 
        public int? StatusId { get; set; }
        public bool? IsRentable { get; set; }
        public bool? IsPurchased { get; set; }

        public AddInventoryRequest()
        {

        }

        public AddInventoryRequest(bool isRentable)
        {
            IsRentable = isRentable;
        }

        public AddInventoryRequest(int id, int? itemId, int? statusId, bool? isRentable, bool? isPurchased)
        {
            Id = id;
            ItemId = itemId;
            StatusId = statusId;
            IsRentable = isRentable;
            IsPurchased = isPurchased;
        }
    }
}

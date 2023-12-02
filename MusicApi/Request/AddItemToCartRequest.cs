namespace MusicApi.Request
{
    public class AddItemToCartRequest
    {
        public string userEmail { get; set; }
        public int ItemId { get; set; }
        public string StatusName { get; set; }
        public int Quantity { get; set; }
    }
}

namespace MusicApi.Request
{
    public class AddItemRentalRequest
    {
        public string? UserEmail { get; set; }  

        public int? ItemId { get; set; }
        public decimal? FinalRentalPrice { get; set; }

        public AddItemRentalRequest() 
        {
        
        }

        public AddItemRentalRequest(int itemId, decimal finalRentalPrice, string userEmail)
        {
            ItemId = itemId;
            FinalRentalPrice = finalRentalPrice;
            UserEmail = userEmail;
        }
    }
}

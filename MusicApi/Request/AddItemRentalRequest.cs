namespace MusicApi.Request
{
    public class AddItemRentalRequest
    {
        public string? UserEmail { get; set; }  

        public int? InventoryId { get; set; }
        public decimal? FinalRentalPrice { get; set; }

        public string? OutCondition { get; set; }

        public AddItemRentalRequest() 
        {
        
        }

        public AddItemRentalRequest(int inventoryId, decimal finalRentalPrice, string outCondition, string userEmail)
        {
            InventoryId = inventoryId;
            FinalRentalPrice = finalRentalPrice;
            OutCondition = outCondition;
            UserEmail = userEmail;
        }
    }
}

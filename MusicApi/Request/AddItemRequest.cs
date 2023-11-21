namespace MusicApi.FrontFacingData
{
    public class AddItemRequest
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemText { get; set; }
        public decimal? SellPrice { get; set; }
        public decimal? RentPrice { get; set; }
        public string? ImageFilePath { get; set; }
        public AddItemRequest()
        {
            
        }

        public AddItemRequest(int id, string itemName ,string itemText, decimal? sellPrice, decimal? rentPrice, string? imageFilePath)
        {
            Id = id;
            ItemName = itemName;
            ItemText = itemText;
            SellPrice = sellPrice;
            RentPrice = rentPrice;
            ImageFilePath = imageFilePath;
        }
    }
}

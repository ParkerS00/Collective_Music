namespace MusicApi.FrontFacingData
{
    public class AddItemRequest
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemText { get; set; }
        public string SKU { get; set; }
        public decimal? SellPrice { get; set; }
        public decimal? RentPrice { get; set; }
        public string? ImageFilePath { get; set; }
        public bool IsPrimary { get; set; }
        public AddItemRequest()
        {
            
        }

        public AddItemRequest(int id, string itemName ,string itemText, string sku, decimal? sellPrice, decimal? rentPrice, string? imageFilePath, bool isPrimary)
        {
            if (id > 0)
            {
                Id = id;
            }
            ItemName = itemName;
            ItemText = itemText;
            SKU = sku;
            SellPrice = sellPrice;
            RentPrice = rentPrice;
            ImageFilePath = imageFilePath;
            IsPrimary = isPrimary;
        }
    }
}

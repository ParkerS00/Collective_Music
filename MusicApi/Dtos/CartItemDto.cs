namespace MusicApi.Dtos
{
    public class CartItemDto
    {
        public string StatusName { get; set; }
        public int Quantity { get; set; }
        public ItemDto Item { get; set; }
    }
}

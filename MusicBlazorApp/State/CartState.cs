using MusicApi.Dtos;

namespace MusicBlazorApp.State
{
    public class CartState
    {
        public List<CartItemDto>? SelectedItems { get; set; } = null;
    }
}

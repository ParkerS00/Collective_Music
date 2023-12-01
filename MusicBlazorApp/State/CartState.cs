using MusicApi.Data;

namespace MusicBlazorApp.State
{
    public class CartState
    {
        public List<ItemDto> SelectedItems { get; set; } = new List<ItemDto>();
    }
}

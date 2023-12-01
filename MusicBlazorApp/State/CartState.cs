using MusicApi.Dtos;

namespace MusicBlazorApp.State
{
    public class CartState
    {
        public List<ItemDto> SelectedItems { get; set; } = new List<ItemDto>();
    }
}

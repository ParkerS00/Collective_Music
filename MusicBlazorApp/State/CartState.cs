using MusicApi.Data;
using MusicApi.Dtos;

namespace MusicBlazorApp.State
{
    public class CartState
    {
        public List<CartItemDto>? SelectedItems { get; set; } = null;
        public IConfiguration config { get; set; }

        public CartState(IConfiguration config)
        {
            this.config = config;
        }

        public async Task RefreshCart(string email)
        {
            if(email == "")
            {
                SelectedItems= new List<CartItemDto>();
                return;
            }

            var httpClient = new HttpClient();

            var customer = await httpClient.GetFromJsonAsync<Customer?>($"{config[Constants.ApiEndpoint]}/customer/{email}");

            if (customer is not null)
            {
                SelectedItems = await httpClient.GetFromJsonAsync<List<MusicApi.Dtos.CartItemDto>>($"{config[Constants.ApiEndpoint]}/cart/{email}");
                //var response = await httpClient.PostAsJsonAsync($"{config[Constants.ApiEndpoint]}/customer/{request}", request);
            }
        }
    }
}

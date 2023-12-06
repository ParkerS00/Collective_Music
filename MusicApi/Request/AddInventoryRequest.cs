namespace MusicApi.Request
{
    public class AddInventoryRequest
    {
        public string? Email { get; set; }

        public AddInventoryRequest()
        {

        }

        public AddInventoryRequest(string email)
        {
            Email = email;
        }
    }
}

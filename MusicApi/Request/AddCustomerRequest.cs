namespace MusicApi.Request
{
    public class AddCustomerRequest
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }

        public int? RewardPoints { get; set; }

        public AddCustomerRequest()
        {

        }

        public AddCustomerRequest(string userEmail)
        {
            Email = userEmail;
        }

        public AddCustomerRequest(string userEmail, string userFirstName, string userLastName, string userAddress, string userPhoneNumber)
        {
            Email= userEmail;
            FirstName= userFirstName;
            LastName= userLastName;
            Address= userAddress;
            PhoneNumber = userPhoneNumber;
        }
    }
}

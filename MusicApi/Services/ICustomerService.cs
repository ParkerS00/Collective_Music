namespace MusicApi.Services;

public interface ICustomerService<Customer>
{
    Task<IEnumerable<Customer>> GetAll();

    Task<Customer> Add(Customer customer);  
}

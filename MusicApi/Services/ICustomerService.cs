namespace MusicApi.Services;

public interface ICustomerService<Customer>
{
    Task<IEnumerable<Customer>> GetAll();
}

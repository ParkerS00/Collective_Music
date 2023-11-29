using Microsoft.EntityFrameworkCore;
using MusicBlazorApp.Data;

namespace MusicApi.Services;

public class CustomerService : ICustomerService<Customer>
{
    private readonly ILogger<ReviewService> _logger;
    private IDbContextFactory<MusicDbContext> _contextFactory;

    public CustomerService(ILogger<ReviewService> logger, IDbContextFactory<MusicDbContext> contextFactory)
    {
        _logger = logger;
        _contextFactory = contextFactory;
    }
    public async Task<IEnumerable<Customer>> GetAll()
    {
        var context = _contextFactory.CreateDbContext();
        return await context.Customers.ToListAsync();
    }

    public async Task<Customer> Add(Customer customer)
    {
        var context = _contextFactory.CreateDbContext();
        context.Customers.Add(customer);
        await context.SaveChangesAsync();
        return customer;
    }
}

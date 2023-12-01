using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
    
    public async Task<Customer> Update(Customer customer)
    {
        //Get item from db
        var context = _contextFactory.CreateDbContext();
        var cuc = await context.Customers.Where(c => c.Email == customer.Email).FirstOrDefaultAsync();

        //alter item from db
        cuc.FirstName = customer.FirstName;
        cuc.LastName = customer.LastName;
        cuc.Address = customer.Address;
        cuc.PhoneNumber = customer.PhoneNumber;

        //Put back in the database
        context.Customers.Update(cuc);
        await context.SaveChangesAsync();

        return cuc;
    }

}

using Microsoft.AspNetCore.Mvc;
using MusicApi.Data;
using MusicApi.Request;
using MusicApi.Services;
using System.Net.Http;
using System.Runtime.InteropServices;

[Route("[controller]")]
[ApiController]
public class CustomerController : Controller
{
    private readonly ILogger<CustomerController> logger;
    private readonly ICustomerService<Customer> customerService;

    public CustomerController(ILogger<CustomerController> logger, ICustomerService<Customer> customerService)
    {
        this.logger = logger;
        this.customerService = customerService;
    }

    [HttpGet("{email}")]
    public async Task<Customer?> Get(string name)
    {
        var allCustomers = await customerService.GetAll();

        try
        {
            return allCustomers.Where(a => a.Email == name).First();
        }
        catch
        {
            return null;
        }
    }

    [HttpGet()]
    public async Task<IEnumerable<Customer>> GetAll()
    {
        logger.LogInformation("Getting all Customers");
        return await this.customerService.GetAll();
    }

    [HttpPost("{customerRequest}")]
    public async Task Post([FromBody] AddCustomerRequest request)
    {
        var customer = new Customer()
        {
            Email = request.Email,
        };

        await customerService.Add(customer);
    }

    [HttpPatch("{customerRequest}")]
    public async Task Update(AddCustomerRequest updateCustomer)
    {
        var Customer = new Customer()
        {
            Email = updateCustomer.Email,
            FirstName = updateCustomer.FirstName,
            LastName = updateCustomer.LastName,
            Address = updateCustomer.Address,
            PhoneNumber = updateCustomer.PhoneNumber,
        };

        await customerService.Update(Customer);
    }
}



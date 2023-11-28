using Microsoft.AspNetCore.Mvc;
using MusicApi.Controllers;
using MusicApi.Request;
using MusicApi.Services;
using MusicBlazorApp.Data;

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

    [HttpGet()]
    public async Task<IEnumerable<Customer>> GetAll()
    {
        logger.LogInformation("Getting all Customers");
        return await this.customerService.GetAll();
    }

}



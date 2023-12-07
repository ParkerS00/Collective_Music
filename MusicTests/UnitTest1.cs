using MusicApi.Data;
using FluentAssertions;
using System.Net.Http.Json;

namespace Dadabase.IntegrationTests;

public class CustomerController : IClassFixture<BlazorIntegrationTestContext>
{
    private readonly HttpClient httpClient;

    public CustomerController(BlazorIntegrationTestContext factory)
    {
        httpClient = factory.CreateDefaultClient();
    }

    [Fact]
    public async Task GetsCorrectCustomerFromDatabase()
    {
        var response = await httpClient.GetAsync($"/customer/admin@snow.edu");
        var customers = await response.Content.ReadFromJsonAsync<Customer> ();
        var customer1 = customers;
        customer1.Should().BeEquivalentTo(new Customer
        {
            Id = 82,
            FirstName = "Admin",
            LastName = "Admin",
            Email = "admin@snow.edu",
            Address = "Admin",
            PhoneNumber = "Admin"
        });
    }
}
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
    public async Task CanCallApi()
    {
        var response = await httpClient.GetAsync($"/customer");
        var customers = await response.Content.ReadFromJsonAsync < List < Customer>> ();
        var customer1 = customers[0];
        customer1.Should().BeEquivalentTo(new Customer
        {
            Id = 82,
            FirstName = "Admin",
            LastName = "Admin",
            Email = "admin@snow.edu",
            Address = "Admin",
            PhoneNumber = "Admin"
        }, o => o.Excluding(si => new { si.CartItems, si.Rentals, si.Purchases }));
    }
}
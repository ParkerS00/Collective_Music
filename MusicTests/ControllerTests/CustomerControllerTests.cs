using MusicApi.Data;
using FluentAssertions;
using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace MusicTests.ControllerTests;

public class CustomerControllerTests : IClassFixture<ApiTestContext>
{
    private readonly HttpClient httpClient;

    public CustomerControllerTests(ApiTestContext factory)
    {
        httpClient = factory.CreateDefaultClient();
    }

    [Fact]
    public async Task GetsCorrectCustomerFromDatabase()
    {
        var response = await httpClient.GetAsync($"/customer/admin@snow.edu");
        var customers = await response.Content.ReadFromJsonAsync<Customer>();
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

    [Fact]
    public async Task GetNullIfCustomerDoesntExist()
    {
        //Arrange
        string badEmail = "THISSHOULDNTWORK";

        //Act
        var response = await httpClient.GetAsync($"/customer/{badEmail}");
        var customer = await response.Content.ReadAsStringAsync();
        var result = string.IsNullOrEmpty(customer) ? null : JsonNode.Parse(customer);

        //Assert
        Assert.Equal(result, null);

    }
}
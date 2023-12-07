using Azure;
using FluentAssertions;
using MusicApi.Data;
using MusicApi.Dtos;
using MusicApi.FrontFacingData;
using System.Net.Http.Json;

namespace MusicTests.ControllerTests;

public class ItemControllerTests : IClassFixture<ApiTestContext>
{
    private readonly HttpClient httpClient;

    public ItemControllerTests(ApiTestContext factory)
    {
        httpClient = factory.CreateDefaultClient();
    }

    [Fact]
    public async Task GettingAllItemsWorksCorrectly()
    {
        //Arrange
        //Act
        var items = await httpClient.GetFromJsonAsync<List<ItemDto>>($"/items");

        //Assert
        items.Count().Should().Be(52);
    }

    [Fact]
    public async Task GettingASingleItemWorksCorrectly()
    {
        //Arrange
        var itemId = 1;

        //Act
        var item = await httpClient.GetFromJsonAsync<ItemDto>($"/items/{itemId}");

        //Assert
        item.ItemName.Should().Be("Toad");
    }

    [Fact]
    public async Task GettingAnIncorrectItemReturnsNull()
    {
        //Arrange
        var badItemId1 = -1;
        var badItemId2 = int.MinValue;

        //Act
        var item = await httpClient.GetAsync($"/items/{badItemId1}");
        var item2 = await httpClient.GetAsync($"/items/{badItemId2}");

        var value1 = await item.Content.ReadAsStringAsync();
        var value2 = await item2.Content.ReadAsStringAsync();


        //Assert
        value1.Should().Be("");
        value2.Should().Be("");
    }

    [Fact]
    public async Task UpdatingItemWorksCorrectly()
    {
        //Arrange / Double check the current item
        var itemId = 1;
        var item = await httpClient.GetFromJsonAsync<ItemDto>($"/items/{itemId}");
        item.ItemName.Should().Be("Toad");

        var itemRequest = new AddItemRequest(item.Id, "Not Toad", item.Description, item.SerialNumber, item.SellPrice, item.SuggestedRentalPrice, ".jpg", false);

        //Act
        await httpClient.PostAsJsonAsync($"/items/{itemRequest}", itemRequest);
        var updatedValue = await httpClient.GetFromJsonAsync<ItemDto>($"/items/{itemId}");

        //Assert
        updatedValue.ItemName.Should().Be("Not Toad");
    }

    [Fact]
    public async Task AddingNewItemWorks()
    {
        //Arrange
        
        var itemRequest = new AddItemRequest(0, "NewItemTest", "Brand new description", "23456gdj", 5.00m, 2.00m, "", false);

        //Act
        var items = await httpClient.GetFromJsonAsync<List<ItemDto>>($"/items");
        await httpClient.PostAsJsonAsync($"/items/{itemRequest}", itemRequest);
        var updatedItems= await httpClient.GetFromJsonAsync<List<ItemDto>>($"/items");

        //Assert
        items.Count().Should().Be(52);
        updatedItems.Count().Should().Be(53);
    }

}

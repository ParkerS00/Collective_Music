using FluentAssertions;
using MusicApi.Data;
using MusicApi.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MusicTests.ControllerTests
{
    public class ReviewControllerTests : IClassFixture<ApiTestContext>
    {
        private readonly HttpClient httpClient;

        public ReviewControllerTests(ApiTestContext factory)
        {
            httpClient = factory.CreateDefaultClient();
        }

        [Fact]
        public async Task GetReviewsSuccessful()
        {
            //Arrange
            var itemToFind = 1;

            //Act
            var reviews = await httpClient.GetFromJsonAsync<List<Review>>($"/review/{itemToFind}");

            //Assert
            reviews.Count().Should().Be(4);

        }

        [Fact]
        public async Task AddReviewsSuccessful()
        {
            //Arrange
            var reviewToAdd = new AddReviewRequest(1, 1, DateOnly.MaxValue, "This is a Test", 5);

            //Act
            await httpClient.PostAsJsonAsync($"/review/{reviewToAdd}", reviewToAdd);
            var newReviews = await httpClient.GetFromJsonAsync<List<Review>>($"/review/1");


            //Assert
            newReviews.Count().Should().Be(5);

        }
    }
}

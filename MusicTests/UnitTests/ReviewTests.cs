using Bunit.TestDoubles;
using Moq;
using MusicApi.Data;
using MusicApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTests.UnitTests
{
    public class ReviewTests
    {
        [Fact]
        public async Task ReviewSuccessfullySubmitted()
        {
            //Arrange
            var mockReview = new Mock<ReviewService>();

            mockReview.Setup(f => f.SaveToDatabase(It.IsAny<Review>())).Verifiable();

            var review = new Review();

            //Act
            await mockReview.Object.Add(review);

            //Assert
            mockReview.VerifyAll();
        }
    }
}

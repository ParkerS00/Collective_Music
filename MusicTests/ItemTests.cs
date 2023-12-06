using Moq;
using MusicApi.Data;
using MusicApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTests
{
    public class ItemTests
    {
        [Fact]
        public async Task TestItemGetIsSuccessful()
        {
            //Arrange
            var mockItemService = new Mock<ItemService>();

            mockItemService.Setup(f => f.GetFromDatabase(It.IsAny<int>())).Verifiable();

            int itemToGet = 1;

            //Act
            await mockItemService.Object.Get(itemToGet);

            //Assert
            mockItemService.VerifyAll();
        }

        [Fact]
        public async Task TestItemGetIsUnsuccessful()
        {
            //Arrange
            var mockItemService = new Mock<ItemService>();


            //values that shouldn't be checked from the database for
            int itemToFail1 = -1;
            int itemToFail2 = int.MinValue;

            //Act
            await mockItemService.Object.Get(itemToFail1);
            await mockItemService.Object.Get(itemToFail2);

            //Assert
            mockItemService.Verify(f => f.GetFromDatabase(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public async Task TestingCorrectImagefilePathUpload()
        {
            //Assert
            var mockItemService = new Mock<ItemService>();
            mockItemService.Setup(f => f.AddImageFilePath(It.IsAny<ItemImage>())).Verifiable();

            string attempted = "thisIsAFilePath.jpg";
            int attemptedItemId = 1;
            bool attemptedBool = false;

            //Act
            await mockItemService.Object.AttemptAddImageFilePath(attempted, attemptedItemId, attemptedBool);

            //Assert
            mockItemService.VerifyAll();
        }

        [Fact]
        public async Task TestingIncorrectImagefilePathUpload()
        {
            //Assert
            var mockItemService = new Mock<ItemService>();

            string goodPath = "thisIsAFilePath.jpg";
            int goodId = 1;
            bool goodBool = false;

            string badPath = "";
            int badId = -1;

            //Act
            await mockItemService.Object.AttemptAddImageFilePath(goodPath, badId, goodBool);
            await mockItemService.Object.AttemptAddImageFilePath(badPath, goodId, goodBool);


            //Assert
            mockItemService.Verify(f => f.AddImageFilePath(It.IsAny<ItemImage>()), Times.Never);
        }
    }
}

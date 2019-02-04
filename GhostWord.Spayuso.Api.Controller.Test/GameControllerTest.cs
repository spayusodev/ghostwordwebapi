using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using GhostWord.Spayuso.Service;
using GhostWord.Spayuso.Controllers;

namespace GhostWord.Spayuso.Api.Controller.Test
{
    public class GameControllerTest
    {
        private readonly Mock<IGameService> _mockService = new Mock<IGameService>();
        
        [Fact]
        public void StartGame_ShouldReturnOkIfGameStartsRight_Test()
        {
            //Arrange
            this._mockService.Setup(serv => serv.StartGame())
                .Returns(true);

            var controller = new GameController(this._mockService.Object);

            //Act
            OkObjectResult result = controller.StartGame() as OkObjectResult;

            //Assert
            Assert.Equal(true, result.Value);
            Assert.NotNull(result);
            Assert.Equal(200,result.StatusCode);
        }

        [Fact]
        public void StartGame_ShouldReturnNotFoundIfGameStartsWrong_Test()
        {
            //Arrange
            var mock = new Mock<IGameService>();
            mock.Setup(serv =>  serv.StartGame())
                .Returns(false);

            var controller = new GameController(this._mockService.Object);

            //Act
            NotFoundObjectResult result = controller.StartGame() as NotFoundObjectResult;

            //Assert
            Assert.Equal(false, result.Value);
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public void AddLetter_ShouldReturnBadRequestIfWordIsNotSupplied_Test()
        {
            //Arrange
            this._mockService.Setup(serv => serv.AddLetter(String.Empty))
                .Returns(String.Empty);

            var controller = new GameController(this._mockService.Object);

            //Act
            BadRequestObjectResult result = controller.AddLetter(String.Empty) as BadRequestObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void AddLetter_ShouldReturnOkResultIfGameWorksRight_Test()
        {
            //Arrange
            this._mockService.Setup(serv => serv.AddLetter("testword"))
                .Returns("testresult");

            var controller = new GameController(this._mockService.Object);

            //Act
            OkObjectResult result = controller.AddLetter("testword") as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
    }
}

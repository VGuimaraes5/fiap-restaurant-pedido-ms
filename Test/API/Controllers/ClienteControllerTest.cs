using API.Controllers;
using Application.Models.ClienteModel;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Test.API.Controllers
{
    public class ClienteControllerTests
    {
        [Fact]
        public async Task Post_ReturnsOkResult_WhenUseCaseExecutesSuccessfully()
        {
            // Arrange
            var mockPostUseCase = new Mock<IUseCaseAsync<ClientePostRequest>>();
            var mockDeleteUseCase = new Mock<IUseCaseAsync<ClienteDeleteRequest>>();
            var controller = new ClienteController(mockPostUseCase.Object, mockDeleteUseCase.Object);
            var request = new ClientePostRequest();

            // Act
            var result = await controller.Post(request);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Post_ReturnsBadRequestResult_WhenUseCaseThrowsException()
        {
            // Arrange
            var mockPostUseCase = new Mock<IUseCaseAsync<ClientePostRequest>>();
            var mockDeleteUseCase = new Mock<IUseCaseAsync<ClienteDeleteRequest>>();
            var controller = new ClienteController(mockPostUseCase.Object, mockDeleteUseCase.Object);
            var request = new ClientePostRequest();

            mockPostUseCase.Setup(useCase => useCase.ExecuteAsync(request)).ThrowsAsync(new Exception());

            // Act
            var result = await controller.Post(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsOkResult_WhenUseCaseExecutesSuccessfully()
        {
            // Arrange
            var mockPostUseCase = new Mock<IUseCaseAsync<ClientePostRequest>>();
            var mockDeleteUseCase = new Mock<IUseCaseAsync<ClienteDeleteRequest>>();
            var controller = new ClienteController(mockPostUseCase.Object, mockDeleteUseCase.Object);
            var request = new ClienteDeleteRequest();

            // Act
            var result = await controller.Delete(request);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsBadRequestResult_WhenUseCaseThrowsException()
        {
            // Arrange
            var mockPostUseCase = new Mock<IUseCaseAsync<ClientePostRequest>>();
            var mockDeleteUseCase = new Mock<IUseCaseAsync<ClienteDeleteRequest>>();
            var controller = new ClienteController(mockPostUseCase.Object, mockDeleteUseCase.Object);
            var request = new ClienteDeleteRequest();

            mockDeleteUseCase.Setup(useCase => useCase.ExecuteAsync(request)).ThrowsAsync(new Exception());

            // Act
            var result = await controller.Delete(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
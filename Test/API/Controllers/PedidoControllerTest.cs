using API.Controllers;
using Application.Models.PedidoModel;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Test.API.Controllers
{
    public class PedidoControllerTests
    {
        private readonly Mock<IUseCaseAsync<PedidoSendRequest, string>> _mockUseCase;
        private readonly Mock<IUseCaseAsync<PedidoSendRequest, string>> _postUseCaseMock;
        private readonly PedidoController _controller;
        private readonly PedidoSendRequest _request;

        public PedidoControllerTests()
        {
            _mockUseCase = new Mock<IUseCaseAsync<PedidoSendRequest, string>>();
            _postUseCaseMock = new Mock<IUseCaseAsync<PedidoSendRequest, string>>();
            _controller = new PedidoController(_mockUseCase.Object);
            _request = new PedidoSendRequest();
        }

        [Fact]
        public async void Post_ReturnCorrect()
        {
            var request = new PedidoSendRequest();
            _postUseCaseMock
                .Setup(r => r.ExecuteAsync(request))
                .ReturnsAsync("Password");
        
            var result = await _controller.Post(request) as OkObjectResult;
        
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task Post_ReturnsBadRequest_WhenUseCaseThrowsException()
        {
            // Arrange
            _mockUseCase.Setup(useCase => useCase.ExecuteAsync(_request))
                .ThrowsAsync(new Exception("Test exception"));
        
            // Act
            var result = await _controller.Post(_request);
        
            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Test exception", badRequestResult.Value);
        }
    }
}
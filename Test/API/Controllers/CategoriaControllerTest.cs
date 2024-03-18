using API.Controllers;
using Application.Models.CategoriaModel;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Test.API.Controllers
{
    public class CategoriaControllerTest
    {
        private readonly CategoriaController _controller;
        private readonly Mock<IUseCaseIEnumerableAsync<IEnumerable<CategoriaResponse>>> _useCaseAsyncResponseMock;

        public CategoriaControllerTest()
        {
            _useCaseAsyncResponseMock = new Mock<IUseCaseIEnumerableAsync<IEnumerable<CategoriaResponse>>>();
            _controller = new CategoriaController(_useCaseAsyncResponseMock.Object);
        }

        [Fact]
        public async void ExecuteAsync_ReturnCorrect()
        {
            _useCaseAsyncResponseMock
                .Setup(r => r.ExecuteAsync())
                .ReturnsAsync(new List<CategoriaResponse>
                {
                    new CategoriaResponse()
                });

            var result = await _controller.GetAllAsync() as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(1, (result.Value as List<CategoriaResponse>)?.Count);
        }
    }
}
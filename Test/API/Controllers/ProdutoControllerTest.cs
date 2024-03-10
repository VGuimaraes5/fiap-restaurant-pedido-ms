using API.Controllers;
using Application.Models.CategoriaModel;
using Application.Models.ProdutoModel;
using Application.UseCases;
using Application.UseCases.ProdutoUseCase;
using AutoMapper;
using Domain.Entities;
using Domain.Gateways;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;

namespace Test.API.Controllers
{
    public class ProdutoControllerTest
    {
        private readonly Mock<IUseCaseIEnumerableAsync<ProdutoRequest, IEnumerable<ProdutoResponse>>> _getByCategoriauseCase;
        private readonly Mock<IUseCaseIEnumerableAsync<IEnumerable<ProdutoResponse>>> _getAlluseCase;
        private readonly Mock<IUseCaseAsync<ProdutoPostRequest>> _postUseCase;
        private readonly Mock<IUseCaseAsync<ProdutoPutRequest>> _putUseCase;
        private readonly Mock<IUseCaseAsync<ProdutoDeleteRequest>> _deleteUseCase;
        private readonly ProdutoController _controller;

        public ProdutoControllerTest()
        {
            _getByCategoriauseCase = new Mock<IUseCaseIEnumerableAsync<ProdutoRequest, IEnumerable<ProdutoResponse>>>();
            _getAlluseCase = new Mock<IUseCaseIEnumerableAsync<IEnumerable<ProdutoResponse>>>();
            _postUseCase = new Mock<IUseCaseAsync<ProdutoPostRequest>>();
            _putUseCase = new Mock<IUseCaseAsync<ProdutoPutRequest>>();
            _deleteUseCase = new Mock<IUseCaseAsync<ProdutoDeleteRequest>>();
            _controller = new ProdutoController(_getByCategoriauseCase.Object, _getAlluseCase.Object, _postUseCase.Object, _putUseCase.Object, _deleteUseCase.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnOkResult_WhenProdutosExist()
        {
            // Arrange
            var produtos = new List<ProdutoResponse> { new ProdutoResponse() };
            _getAlluseCase.Setup(x => x.ExecuteAsync()).ReturnsAsync(produtos);

            // Act
            var result = await _controller.GetAllAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<ProdutoResponse>>(okResult.Value);
            Assert.Equal(produtos, returnValue);
        }

        [Fact]
        public async Task GetProdutoByCategoriaId_ShouldReturnOkResult_WhenProdutoExists()
        {
            // Arrange
            var request = new ProdutoRequest { CategoriaId = Guid.NewGuid() };
            var produtos = new List<ProdutoResponse> { new ProdutoResponse() };
            _getByCategoriauseCase.Setup(x => x.ExecuteAsync(request)).ReturnsAsync(produtos);

            // Act
            var result = await _controller.GetProdutoByCategoriaId(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<ProdutoResponse>>(okResult.Value);
            Assert.Equal(produtos, returnValue);
        }

        [Fact]
        public async Task Post_ShouldReturnOkResult_WhenRequestIsValid()
        {
            // Arrange
            var request = new ProdutoPostRequest();
            _postUseCase.Setup(x => x.ExecuteAsync(request)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Post(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Put_ShouldReturnOkResult_WhenRequestIsValid()
        {
            // Arrange
            var id = Guid.NewGuid();
            var request = new ProdutoPutRequest();
            _putUseCase.Setup(x => x.ExecuteAsync(request)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Put(id, request);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Delete_ShouldReturnOkResult_WhenRequestIsValid()
        {
            // Arrange
            var request = new ProdutoDeleteRequest { Id = Guid.NewGuid() };
            _deleteUseCase.Setup(x => x.ExecuteAsync(request)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Delete(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
using Application.Models.ProdutoModel;
using Application.UseCases.ProdutoUseCase;
using AutoMapper;
using Domain.Entities;
using Domain.Gateways;
using Moq;

namespace Test.Application.UseCases.ProdutoUseCase
{
    public class PostProdutoUseCaseAsyncTest
    {
        private readonly PostProdutoUseCaseAsync _service;
        private readonly Mock<IProdutoGateway> _produtoGatewayMock;
        private readonly Mock<ICategoriaGateway> _categoriaGatewayMock;

        public PostProdutoUseCaseAsyncTest()
        {
            var mapperMock = new Mock<IMapper>();
            _produtoGatewayMock = new Mock<IProdutoGateway>();
            _categoriaGatewayMock = new Mock<ICategoriaGateway>();
            _service = new PostProdutoUseCaseAsync(_produtoGatewayMock.Object, _categoriaGatewayMock.Object, mapperMock.Object);
        }

        [Fact]
        public async void ExecuteAsync_ReturnCorrect()
        {
            _categoriaGatewayMock
                .Setup(r => r.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new Categoria("Bebida", Guid.NewGuid()));

            _produtoGatewayMock
                .Setup(r => r.InsertAsync(It.IsAny<Produto>()));

            try
            {
                await _service.ExecuteAsync(new ProdutoPostRequest());
                Assert.True(true);
                _categoriaGatewayMock.Verify(m => m.GetAsync(It.IsAny<Guid>()), Times.Once);
                _produtoGatewayMock.Verify(m => m.InsertAsync(It.IsAny<Produto>()), Times.Once);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async void ExecuteAsync_ReturnError()
        {
            _categoriaGatewayMock
                .Setup(r => r.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(value: null);

            try
            {
                await _service.ExecuteAsync(new ProdutoPostRequest());
                Assert.False(true);
            }
            catch (Exception ex)
            {
                Assert.False(false);
                Assert.Equal("Categoria não encontrado", ex.Message);
                _categoriaGatewayMock.Verify(m => m.GetAsync(It.IsAny<Guid>()), Times.Once);
                _produtoGatewayMock.Verify(m => m.InsertAsync(It.IsAny<Produto>()), Times.Never);
            }
        }
    }
}
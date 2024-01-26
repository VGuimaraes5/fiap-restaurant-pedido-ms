using Application.Models.ProdutoModel;
using Application.UseCases.ProdutoUseCase;
using AutoMapper;
using Domain.Entities;
using Domain.Gateways;
using Moq;

namespace Test.Application.UseCases.ProdutoUseCase
{
    public class PutProdutoUseCaseAsyncTest
    {
        private readonly Mock<IProdutoGateway> _produtoGateway;
        private readonly Mock<ICategoriaGateway> _categoriaGateway;
        private readonly Mock<IMapper> _mapper;

        public PutProdutoUseCaseAsyncTest()
        {
            _produtoGateway = new Mock<IProdutoGateway>();
            _categoriaGateway = new Mock<ICategoriaGateway>();
            _mapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task ExecuteAsync_WithValidRequest_ShouldUpdateProduto()
        {
            // Arrange
            var request = new ProdutoPutRequest { Id = Guid.NewGuid(), CategoriaId = Guid.NewGuid() };
            var produto = new Produto("Lanche01", 12.45m, Guid.NewGuid(), Guid.NewGuid());
            _produtoGateway.Setup(x => x.GetAsync(request.Id.Value)).ReturnsAsync(produto);
            _categoriaGateway.Setup(x => x.GetAsync(request.CategoriaId.Value)).ReturnsAsync(new Categoria("Lanche", Guid.NewGuid()));
            _mapper.Setup(x => x.Map<ProdutoPutRequest, Produto>(request)).Returns(produto);
            var useCase = new PutProdutoUseCaseAsync(_produtoGateway.Object, _categoriaGateway.Object, _mapper.Object);

            // Act
            await useCase.ExecuteAsync(request);

            // Assert
            _produtoGateway.Verify(x => x.UpdateAsync(produto), Times.Once);

        }
    }
}
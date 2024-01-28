using Application.Models.ProdutoModel;
using Application.UseCases.ProdutoUseCase;
using AutoMapper;
using Domain.Entities;
using Domain.Gateways;
using Microsoft.Extensions.Caching.Memory;
using Moq;

namespace Test.Application.UseCases.ProdutoUseCase
{
    public class GetAllProdutoUseCaseAsyncTest
    {
        private readonly Mock<IProdutoGateway> _gateway;
        private readonly Mock<IMapper> _mapper;
        private readonly MemoryCache _memoryCache;

        public GetAllProdutoUseCaseAsyncTest()
        {
            _gateway = new Mock<IProdutoGateway>();
            _mapper = new Mock<IMapper>();
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
        }

        [Fact]
        public async Task ExecuteAsync_ShouldReturnAllProdutos()
        {
            // Arrange
            var produtos = new List<Produto> { new Produto( "Lanche01", 12.45m, Guid.NewGuid(), Guid.NewGuid()) };
            _gateway.Setup(x => x.GetAllAsync()).ReturnsAsync(produtos);
            var useCase = new GetAllProdutoUseCaseAsync(_gateway.Object, _mapper.Object, _memoryCache);

            // Act
            var result = await useCase.ExecuteAsync();

            // Assert
            Assert.NotNull(result);
        }
    }

}
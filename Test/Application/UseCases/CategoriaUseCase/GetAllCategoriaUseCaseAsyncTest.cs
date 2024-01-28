using Application.UseCases.CategoriaUseCase;
using AutoMapper;
using Domain.Entities;
using Domain.Gateways;
using Moq;

namespace Test.Application.UseCases.CategoriaUseCase
{
    public class GetAllCategoriaUseCaseAsyncTest
    {
        private readonly GetAllCategoriaUseCaseAsync _service;
        private readonly Mock<ICategoriaGateway> _categoriaGatewayMock;

        public GetAllCategoriaUseCaseAsyncTest()
        {
            var mapperMock = new Mock<IMapper>();
            _categoriaGatewayMock = new Mock<ICategoriaGateway>();
            _service = new GetAllCategoriaUseCaseAsync(_categoriaGatewayMock.Object, mapperMock.Object);
        }

        [Fact]
        public async void ExecuteAsync_ReturnCorrect()
        {
            _categoriaGatewayMock
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(new List<Categoria>
                {
                    new Categoria("Bebida", Guid.NewGuid())
                });

            var result = (await _service.ExecuteAsync()).ToList();

            Assert.NotNull(result);
        }
    }
}
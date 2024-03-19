using Application.Models.PedidoModel;
using Application.UseCases.PedidoUseCase;
using AutoMapper;
using Domain.Bus;
using Domain.Models;
using Domain.Enums;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Test.Application.UseCases.PedidoUseCase
{
    public class PedidoSendUseCaseAsyncTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IPedidoBus> _pedidoBusMock;
        private readonly PedidoSendUseCaseAsync _useCase;

        public PedidoSendUseCaseAsyncTests()
        {
            _pedidoBusMock = new Mock<IPedidoBus>();
            _mapperMock = new Mock<IMapper>();
            _useCase = new PedidoSendUseCaseAsync(_pedidoBusMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task ExecuteAsync_ShouldWorkCorrectly()
        {
            // Arrange
            var request = new PedidoSendRequest();
            var mappedPedido = new PedidoModel
            {
                Produtos = new List<PedidoProdutoModel>(),
                TipoPagamento = TipoPagamento.Cartao,
                IdCliente = Guid.NewGuid(),
                Senha = "TestPassword"
            };
            _mapperMock.Setup(m => m.Map<PedidoSendRequest, PedidoModel>(request)).Returns(mappedPedido);

            // Act
            var result = await _useCase.ExecuteAsync(request);

            // Assert
            _mapperMock.Verify(m => m.Map<PedidoSendRequest, PedidoModel>(request), Times.Once);
            _pedidoBusMock.Verify(p => p.SendAsync(mappedPedido), Times.Once);
            Assert.Equal(mappedPedido.Senha, result);
        }

    }
}
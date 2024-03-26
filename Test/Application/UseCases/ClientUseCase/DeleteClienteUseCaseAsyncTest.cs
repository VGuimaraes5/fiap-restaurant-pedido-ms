using Application.UseCases.ClienteUseCase;
using Application.Models.ClienteModel;
using Domain.Entities;
using Domain.Gateways;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Test.Application.UseCases.ClientUseCase
{
    public class DeleteClienteUseCaseAsyncTests
    {
        [Fact]
        public async Task ExecuteAsync_ThrowsKeyNotFoundException_WithCorrectMessage_WhenClienteDoesNotExist()
        {
            // Arrange
            var mockClienteGateway = new Mock<IClienteGateway>();
            var mockCognitoGateway = new Mock<ICognitoGateway>();
            var useCase = new DeleteClienteUseCaseAsync(mockClienteGateway.Object, mockCognitoGateway.Object);
            var request = new ClienteDeleteRequest();

            mockClienteGateway.Setup(gateway => gateway.GetAsync(request.Id)).ReturnsAsync((Cliente?)null);

            // Act
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => useCase.ExecuteAsync(request));

            // Assert
            Assert.Equal("Cliente não encontrado", exception.Message);
        }

        [Fact]
        public async Task ExecuteAsync_DeletesCliente_WhenClienteExists()
        {
            // Arrange
            var mockClienteGateway = new Mock<IClienteGateway>();
            var mockCognitoGateway = new Mock<ICognitoGateway>();
            var useCase = new DeleteClienteUseCaseAsync(mockClienteGateway.Object, mockCognitoGateway.Object);
            var request = new ClienteDeleteRequest();
            var cliente = new Cliente("Fulano", "89618227057", "id-fulano-01");

            mockClienteGateway.Setup(gateway => gateway.GetAsync(request.Id)).ReturnsAsync(cliente);

            // Act
            await useCase.ExecuteAsync(request);

            // Assert
            mockCognitoGateway.Verify(gateway => gateway.DeleteUser(cliente.UserId.ToString()), Times.Once);
            mockClienteGateway.Verify(gateway => gateway.DeleteAsync(request.Id), Times.Once);
        }
    }
}
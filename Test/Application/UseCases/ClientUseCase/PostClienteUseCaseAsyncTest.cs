using Application.Models.ClienteModel;
using Application.UseCases.ClienteUseCase;
using AutoMapper;
using Domain.Entities;
using Domain.Gateways;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Test.Application.UseCases.ClientUseCase
{
    public class PostClienteUseCaseAsyncTests
    {
        [Fact]
        public async Task ExecuteAsync_ThrowsInvalidOperationException_WithCorrectMessage_WhenClienteAlreadyExists()
        {
            // Arrange
            var mockClienteGateway = new Mock<IClienteGateway>();
            var mockCognitoGateway = new Mock<ICognitoGateway>();
            var mockMapper = new Mock<IMapper>();
            var useCase = new PostClienteUseCaseAsync(mockClienteGateway.Object, mockMapper.Object, mockCognitoGateway.Object);
            var request = new ClientePostRequest();
            var cliente = new Cliente("Fulano", "89618227057", "id-fulano-01");

            mockMapper.Setup(mapper => mapper.Map<ClientePostRequest, Cliente>(request)).Returns(cliente);
            mockClienteGateway.Setup(gateway => gateway.GetByCPFAsync(cliente.Cpf)).ReturnsAsync(cliente);

            // Act
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => useCase.ExecuteAsync(request));

            // Assert
            Assert.Equal("Já existe um cliente com este CPF cadastrado!", exception.Message);
        }

        [Fact]
        public async Task ExecuteAsync_ShouldAddNewClient_WhenClientDoesNotExist()
        {
            // Arrange
            var clienteGatewayMock = new Mock<IClienteGateway>();
            var mapperMock = new Mock<IMapper>();
            var cognitoGatewayMock = new Mock<ICognitoGateway>();
            var useCase = new PostClienteUseCaseAsync(clienteGatewayMock.Object, mapperMock.Object, cognitoGatewayMock.Object);

            var request = new ClientePostRequest { Nome = "Fulano", Cpf = "89618227057" };
            var cliente = new Cliente("Fulano", "89618227057", "id-fulano-01");

            mapperMock.Setup(m => m.Map<ClientePostRequest, Cliente>(request)).Returns(cliente);
            clienteGatewayMock.Setup(c => c.GetByCPFAsync(cliente.Cpf)).ReturnsAsync((Cliente?)null);
            cognitoGatewayMock.Setup(c => c.CreateUser(cliente)).ReturnsAsync("userId");
            clienteGatewayMock.Setup(c => c.InsertAsync(cliente)).Returns(Task.CompletedTask);

            // Act
            await useCase.ExecuteAsync(request);

            // Assert
            clienteGatewayMock.Verify(c => c.InsertAsync(cliente), Times.Once);
        }
    }
}
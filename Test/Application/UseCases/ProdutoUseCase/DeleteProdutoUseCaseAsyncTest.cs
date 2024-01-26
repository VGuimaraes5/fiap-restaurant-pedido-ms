using Application.Models.ProdutoModel;
using Application.UseCases.ProdutoUseCase;
using AutoMapper;
using Domain.Entities;
using Domain.Gateways;
using Moq;

namespace Test.Application.UseCases.ProdutoUseCase
{
	public class DeleteProdutoUseCaseAsyncTest
	{
		private readonly Mock<IProdutoGateway> _gateway;

		public DeleteProdutoUseCaseAsyncTest()
		{
			_gateway = new Mock<IProdutoGateway>();
		}

		[Fact]
		public async Task ExecuteAsync_WithValidRequest_ShouldDeleteProduto()
		{
			// Arrange
			var request = new ProdutoDeleteRequest { Id = Guid.NewGuid() };
			var produto = new Produto("Lanche01", 12.45m, Guid.NewGuid(), Guid.NewGuid());
			_gateway.Setup(x => x.GetAsync(request.Id)).ReturnsAsync(produto);
			var useCase = new DeleteProdutoUseCaseAsync(_gateway.Object);

			// Act
			await useCase.ExecuteAsync(request);

			// Assert
			_gateway.Verify(x => x.DeleteAsync(request.Id), Times.Once);
		}
	}
}

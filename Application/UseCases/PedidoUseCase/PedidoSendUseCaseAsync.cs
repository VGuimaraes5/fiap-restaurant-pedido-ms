using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Models.PedidoModel;
using AutoMapper;
using Domain.Bus;
using Domain.Models;

namespace Application.UseCases.PedidoUseCase
{
    public class PedidoSendUseCaseAsync : IUseCaseAsync<PedidoSendRequest, string>
    {
        private readonly IPedidoBus _pedidoBus;
        private readonly IMapper _mapper;

        public PedidoSendUseCaseAsync(IPedidoBus pedidoBus, IMapper mapper)
        {
            _pedidoBus = pedidoBus;
            _mapper = mapper;
        }

        public async Task<string> ExecuteAsync(PedidoSendRequest request)
        {
            var pedido = _mapper.Map<PedidoSendRequest, PedidoModel>(request);
            pedido.Senha = this.RandomString(6);

            await _pedidoBus.SendAsync(pedido);

            return pedido.Senha;
        }

        private string RandomString(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Bus
{
    public interface IPedidoBus
    {
        Task SendAsync(PedidoModel model);
    }
}
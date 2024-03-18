using System;
using System.Collections.Generic;
using Domain.Enums;

namespace Domain.Models
{
    public class PedidoModel
    {
        public Guid PedidoId { get; } = Guid.NewGuid();
        public List<PedidoProdutoModel> Produtos { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public Guid? IdCliente { get; set; }
        public string Senha { get; set; }
    }
}
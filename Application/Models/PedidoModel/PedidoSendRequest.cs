using System;
using System.Collections.Generic;
using Application.Models.ValueObject;
using Domain.Enums;
using Newtonsoft.Json;

namespace Application.Models.PedidoModel
{
    public class PedidoSendRequest
    {
        [JsonProperty("Produtos")]
        public List<ProdutoVO> Produtos { get; set; }

        [JsonProperty("TipoPagamento")]
        public TipoPagamento TipoPagamento { get; set; }

        [JsonProperty("IdCliente")]
        public Guid? IdCliente { get; set; }
    }
}
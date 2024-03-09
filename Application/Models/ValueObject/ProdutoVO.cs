using Newtonsoft.Json;

namespace Application.Models.ValueObject
{
    public class ProdutoVO
    {
        [JsonProperty("NomeProduto")]
        public string NomeProduto { get; set; }

        [JsonProperty("ValorProduto")]
        public decimal ValorProduto { get; set; }

        [JsonProperty("Observacao")]
        public string Observacao { get; set; }
    }
}

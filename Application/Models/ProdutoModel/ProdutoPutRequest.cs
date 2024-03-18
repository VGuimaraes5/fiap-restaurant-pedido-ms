using Newtonsoft.Json;
using System;

namespace Application.Models.ProdutoModel
{
    public class ProdutoPutRequest
    {
        public ProdutoPutRequest()
        {
            Nome = string.Empty;
            Valor = 0;
            CategoriaId = Guid.Empty;
            Id = Guid.Empty;
        }

        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public Guid? CategoriaId { get; set; }
    }
}

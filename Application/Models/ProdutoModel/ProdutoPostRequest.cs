using System;

namespace Application.Models.ProdutoModel
{
    public class ProdutoPostRequest
    {
        public ProdutoPostRequest()
        {
            Nome = string.Empty;
            Valor = 0;
            CategoriaId = Guid.Empty;
        }

        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public Guid? CategoriaId { get; set; }
    }
}

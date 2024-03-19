using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Application.Models.ClienteModel
{
    [ExcludeFromCodeCoverage]
    public class ClientePostRequest
    {
        public ClientePostRequest()
        {
            Nome = string.Empty;
            Cpf = string.Empty;
        }

        [JsonProperty("Nome")]
        public string Nome { get; set; }

        [JsonProperty("Cpf")]
        public string Cpf { get; set; }
    }
}
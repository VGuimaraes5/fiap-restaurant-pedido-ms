using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Application.Models.ClienteModel
{
    [ExcludeFromCodeCoverage]
    public class ClienteDeleteRequest
    {
        public ClienteDeleteRequest()
        {
            Id = Guid.Empty;
        }

        [FromRoute]
        public Guid Id { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.Models.CategoriaModel;
using Application.UseCases;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly IUseCaseIEnumerableAsync<IEnumerable<CategoriaResponse>> _useCaseAsyncResponse;
        private readonly ILogger<CategoriaController> _logger;

        public CategoriaController(ILogger<CategoriaController> logger, IUseCaseIEnumerableAsync<IEnumerable<CategoriaResponse>> useCaseAsyncResponse)
        {
            _logger = logger;
            _useCaseAsyncResponse = useCaseAsyncResponse;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _useCaseAsyncResponse.ExecuteAsync();

            if (result.Any())
            {
                return Ok(result);
            }

            return NoContent();
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Application.Models.CategoriaModel;
using Application.UseCases;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly IUseCaseIEnumerableAsync<IEnumerable<CategoriaResponse>> _useCaseAsyncResponse;

        public CategoriaController(IUseCaseIEnumerableAsync<IEnumerable<CategoriaResponse>> useCaseAsyncResponse)
        {
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

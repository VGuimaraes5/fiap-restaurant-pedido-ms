using Microsoft.AspNetCore.Mvc;
using Application.Models.PedidoModel;
using Application.UseCases;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IUseCaseAsync<PedidoSendRequest, string> _postUseCase;

        public PedidoController(IUseCaseAsync<PedidoSendRequest, string> postUseCase)
        {
            _postUseCase = postUseCase;
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] PedidoSendRequest request)
        {
            try
            {
                var password = await _postUseCase.ExecuteAsync(request);
                return Ok(new
                {
                    Senha = password
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
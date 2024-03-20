using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.UseCases;
using Application.Models.ClienteModel;
using System.Diagnostics.CodeAnalysis;

namespace API.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IUseCaseAsync<ClientePostRequest> _postUseCase;
        private readonly IUseCaseAsync<ClienteDeleteRequest> _deleteUseCase;

        public ClienteController(IUseCaseAsync<ClientePostRequest> postUseCase, IUseCaseAsync<ClienteDeleteRequest> deleteUseCase)
        {
            _postUseCase = postUseCase;
            _deleteUseCase = deleteUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBodyAttribute] ClientePostRequest request)
        {
            try
            {
                await _postUseCase.ExecuteAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] ClienteDeleteRequest request)
        {
            try
            {
                await _deleteUseCase.ExecuteAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
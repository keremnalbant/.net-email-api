using EMailAPI.Domain;
using EMailAPI.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMailAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Users request)
        {
            var command = new LoginCommand(request.username, request.password);
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();

            if (!result.success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

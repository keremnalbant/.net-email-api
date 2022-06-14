using EMailAPI.Domain.Commands;
using EMailAPI.Domain.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EMailAPI.Controllers;

[ApiController]
[Route("api/v1/SendEmail")]
public class SendEmailController : ControllerBase
{
    private readonly ILogger<SendEmailController> _logger;
    private readonly IMediator _mediator;

    public SendEmailController(ILogger<SendEmailController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost(Name = "api/v1/SendEmail")]
    public async Task<IActionResult> Post(SendEmailRequest request)
    {
        var command = new SendEmailCommand(request.Receivers, request.Subject, request.Body);
        var result = await _mediator.Send(command);

        if (result == null) return NotFound();

        if (!result.success)
            return BadRequest(result);
        return Ok(result);
    }
}
using LeMail.Application.Dto_s.Message.Requests;
using LeMail.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeMail.WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;
    private readonly IEmailService _emailService;
    public MessageController( IMessageService messageService, IEmailService emailService)
    {
        _messageService = messageService;
        _emailService = emailService;
    }
    
    [HttpPost] // done
    public async Task<IActionResult> CreateMessage(CreateMessageRequest request, CancellationToken cancellationToken)
    {
        var response = await _messageService.CreateMessageAsync(request, cancellationToken);
        await _emailService.SendEmailAsync(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")] // done
    public async Task<IActionResult> GetMessageById(Guid id)
    {
        var response = await _messageService.GetMessageByIdAsync(id, HttpContext.RequestAborted);
        if (response == null)
            return NotFound();
        return Ok(response);
    }

    [HttpPut] //done
    public async Task<IActionResult> UpdateMessage(UpdateMessageRequest request, CancellationToken cancellationToken)
    {

        var response = await _messageService.UpdateMessageAsync(request, cancellationToken);
        if (response == null)
            return NotFound();
        return Ok(response);
    }

    [HttpDelete("{id}")]//done
    public async Task<IActionResult> DeleteMessage(Guid id, CancellationToken cancellationToken)
    {
        var result = await _messageService.DeleteMessageByIdAsync(id, cancellationToken);
        if (!result)
            return NotFound();
        return NoContent();
    }

    [HttpGet]//done
    public async Task<IActionResult> GetAllMessages(CancellationToken cancellationToken)
    {
        var response = await _messageService.GetAllMessagesAsync(cancellationToken);
        return Ok(response);
    }
    
    [HttpGet("AllBy{id}")]
    public async Task<IActionResult> GetAllMessagesByUserId(Guid id, CancellationToken cancellationToken)
    {
        var response = await _messageService.GetAllListByUserIdAsync(id, cancellationToken);
        return Ok(response);
    }
}
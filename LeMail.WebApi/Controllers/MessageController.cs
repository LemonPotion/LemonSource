using LeMail.Application.Dto_s.Message.Requests;
using LeMail.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeMail.WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;

    public MessageController( IMessageService messageService)
    {
        _messageService = messageService;
    }
    
    [HttpPost] // done
    public async Task<IActionResult> CreateUser(CreateMessageRequest request, CancellationToken cancellationToken)
    {
        var response = await _messageService.CreateMessageAsync(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")] // done
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var response = await _messageService.GetMessageByIdAsync(id, HttpContext.RequestAborted);
        if (response == null)
            return NotFound();
        return Ok(response);
    }

    [HttpPut] //done
    public async Task<IActionResult> UpdateUser(UpdateMessageRequest request)
    {

        var response = await _messageService.UpdateMessageAsync(request, HttpContext.RequestAborted);
        if (response == null)
            return NotFound();
        return Ok(response);
    }

    [HttpDelete("{id}")]//done
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var result = await _messageService.DeleteMessageByIdAsync(id, HttpContext.RequestAborted);
        if (!result)
            return NotFound();
        return NoContent();
    }

    [HttpGet]//done
    public async Task<IActionResult> GetAllUsers()
    {
        var response = await _messageService.GetAllMessagesAsync(HttpContext.RequestAborted);
        return Ok(response);
    }
}
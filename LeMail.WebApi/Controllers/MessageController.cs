using LeMail.Application.Dto_s.Message.Requests;
using LeMail.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeMail.WebApi.Controllers;
/// <summary>
/// Message api controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    /// <summary>
    /// Message Service
    /// </summary>
    private readonly IMessageService _messageService;
    /// <summary>
    /// Email send service
    /// </summary>
    private readonly IEmailService _emailService;
    public MessageController( IMessageService messageService, IEmailService emailService)
    {
        _messageService = messageService;
        _emailService = emailService;
    }
    
    /// <summary>
    /// Create Message query
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateMessage(CreateMessageRequest request, CancellationToken cancellationToken)
    {
        var response = await _messageService.CreateMessageAsync(request, cancellationToken);
        await _emailService.SendEmailAsync(request, cancellationToken);
        return Ok(response);
    }
    /// <summary>
    /// Get Message by id query
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")] 
    public async Task<IActionResult> GetMessageById(Guid id)
    {
        var response = await _messageService.GetMessageByIdAsync(id, HttpContext.RequestAborted);
        if (response == null)
            return NotFound();
        return Ok(response);
    }
    /// <summary>
    /// Update Message by id query
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> UpdateMessage(UpdateMessageRequest request, CancellationToken cancellationToken)
    {

        var response = await _messageService.UpdateMessageAsync(request, cancellationToken);
        if (response == null)
            return NotFound();
        return Ok(response);
    }
    /// <summary>
    /// Delete Message by id query
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMessage(Guid id, CancellationToken cancellationToken)
    {
        var result = await _messageService.DeleteMessageByIdAsync(id, cancellationToken);
        if (!result)
            return NotFound();
        return NoContent();
    }
    /// <summary>
    /// Get all message query
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAllMessages(CancellationToken cancellationToken)
    {
        var response = await _messageService.GetAllMessagesAsync(cancellationToken);
        return Ok(response);
    }
    /// <summary>
    /// Get all message by user id query
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("AllBy{id}")]
    public async Task<IActionResult> GetAllMessagesByUserId(Guid id, CancellationToken cancellationToken)
    {
        var response = await _messageService.GetAllListByUserIdAsync(id, cancellationToken);
        return Ok(response);
    }
}
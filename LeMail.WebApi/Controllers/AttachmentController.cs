using LeMail.Application.Dto_s.Attachment.Requests;
using LeMail.Application.Interfaces.Services;
using LeMail.Domain.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace LeMail.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttachmentController : ControllerBase
{
    private readonly IAttachmentService _attachmentService;

    public AttachmentController(IAttachmentService attachmentService)
    {
        _attachmentService = attachmentService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAttachment(Guid messageId,IFormFile attachment, CancellationToken cancellationToken)
    {
        if (attachment is null|| attachment.Length==0) 
            return BadRequest(string.Format(ExceptionMessages.NullError, nameof(attachment)));

        var response = await _attachmentService.CreateAttachmentAsync(messageId,attachment, cancellationToken);
        return Ok(response);
    }
    
    [HttpGet("File{id}")]
    public async Task<IActionResult> GetAttachmentFileById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _attachmentService.GetAttachmentByIdAsync(id, cancellationToken);
        if (response == null)
            return NotFound();
        
        var contentTypeProvider = new FileExtensionContentTypeProvider();
        if (!contentTypeProvider.TryGetContentType(response.FilePath, out var contentType))
        {
            contentType = "application/octet-stream";
        }
        
        return PhysicalFile(response.FilePath, contentType);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAttachmentById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _attachmentService.GetAttachmentByIdAsync(id, cancellationToken);
        if (response == null)
            return NotFound();
        return Ok(response);
    }
    

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAttachment(Guid id, CancellationToken cancellationToken)
    {
        var result = await _attachmentService.DeleteAttachmentByIdAsync(id, cancellationToken);
        if (!result)
            return NotFound();
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAttachments(CancellationToken cancellationToken)
    {
        var response = await _attachmentService.GetAllAttachmentsAsync(cancellationToken);
        return Ok(response);
    }
}
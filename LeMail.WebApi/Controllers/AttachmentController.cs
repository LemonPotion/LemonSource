using LeMail.Application.Dto_s.Attachment.Requests;
using LeMail.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> CreateAttachment(CreateAttachmentRequest request, CancellationToken cancellationToken)
    {
        var response = await _attachmentService.CreateAttachmentAsync(request, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// get user by id query
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAttachmentById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _attachmentService.GetAttachmentByIdAsync(id, cancellationToken);
        if (response == null)
            return NotFound();
        return Ok(response);
    }
    /// <summary>
    /// update user by id query
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> UpdateUser(UpdateAttachmentRequest request, CancellationToken cancellationToken)
    {

        var response = await _attachmentService.UpdateAttachmentAsync(request, cancellationToken);
        if (response == null)
            return NotFound();
        return Ok(response);
    }
    /// <summary>
    /// Delete User by id query
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]//done
    public async Task<IActionResult> DeleteUser(Guid id, CancellationToken cancellationToken)
    {
        var result = await _attachmentService.DeleteAttachmentByIdAsync(id, cancellationToken);
        if (!result)
            return NotFound();
        return NoContent();
    }
    /// <summary>
    /// Get all users query
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
    {
        var response = await _attachmentService.GetAllAttachmentsAsync(cancellationToken);
        return Ok(response);
    }
}
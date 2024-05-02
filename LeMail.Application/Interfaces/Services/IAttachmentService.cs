using LeMail.Application.Dto_s.Attachment.Requests;
using LeMail.Application.Dto_s.Attachment.Responses;
using LeMail.Application.Dto_s.Contact.Responses;
using Microsoft.AspNetCore.Http;

namespace LeMail.Application.Interfaces.Services;

public interface IAttachmentService
{
    Task<CreateAttachmentResponse> CreateAttachmentAsync(Guid messageId,IFormFile attachment, CancellationToken cancellationToken);
    
    Task<GetAttachmentResponse> GetAttachmentByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<bool> DeleteAttachmentByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<List<GetAttachmentResponse>> GetAllAttachmentsAsync(CancellationToken cancellationToken);
}
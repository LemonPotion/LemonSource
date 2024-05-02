using LeMail.Application.Dto_s.Attachment.Requests;
using LeMail.Application.Dto_s.Attachment.Responses;

namespace LeMail.Application.Interfaces.Services;

public interface IAttachmentService
{
    Task<CreateAttachmentResponse> CreateAttachmentAsync(CreateAttachmentRequest request, CancellationToken cancellationToken);
    
    Task<GetAttachmentResponse> GetAttachmentByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<UpdateAttachmentResponse> UpdateAttachmentAsync(UpdateAttachmentRequest request, CancellationToken cancellationToken);
    
    Task<bool> DeleteAttachmentByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<List<GetAttachmentResponse>> GetAllAttachmentsAsync(CancellationToken cancellationToken);
}
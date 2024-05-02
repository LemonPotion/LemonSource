using LeMail.Application.Dto_s.Contact;

namespace LeMail.Application.Dto_s.Attachment.Requests;

public class UpdateAttachmentRequest : BaseAttachmentDto
{
    public Guid Id { get; init; }
}
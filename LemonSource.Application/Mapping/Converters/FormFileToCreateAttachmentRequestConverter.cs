using AutoMapper;
using LeMail.Application.Dto_s.Attachment.Requests;
using Microsoft.AspNetCore.Http;

namespace LeMail.Application.Mapping.Converters;

public class FormFileToCreateAttachmentRequestConverter : ITypeConverter<IFormFile, CreateAttachmentRequest>
{
    public CreateAttachmentRequest Convert(IFormFile source, CreateAttachmentRequest destination, ResolutionContext context)
    {
        return new CreateAttachmentRequest
        {
            FileName = source.FileName,
            FileType = source.ContentType,
            FilePath = Path.Combine(Directory.GetCurrentDirectory(), $@"FileStorage\{source.FileName}")
        };
    }
}
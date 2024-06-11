using AutoMapper;
using LeMail.Application.Dto_s.Attachment.Requests;
using LeMail.Application.Dto_s.Attachment.Responses;
using LeMail.Application.Interfaces.Repository;
using LeMail.Application.Interfaces.Services;
using LeMail.Domain.Entities;
using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Validators.Entities;
using Microsoft.AspNetCore.Http;

namespace LeMail.Application.Services
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public AttachmentService(IAttachmentRepository attachmentRepository, IMapper mapper, IFileService fileService)
        {
            _attachmentRepository = attachmentRepository;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<CreateAttachmentResponse> CreateAttachmentAsync(Guid articleId,IFormFile attachment, CancellationToken cancellationToken)
        {
            var createAttachmentRequest = _mapper.Map<CreateAttachmentRequest>(attachment);
            
            var attachmentEntity = _mapper.Map<Attachment>(createAttachmentRequest);
            
            var validator = new AttachmentValidator(nameof(Attachment));
            validator.ValidateWithExceptions(attachmentEntity);
            
            await _fileService.CreateFileAsync(attachment, attachmentEntity.FilePath);
            
            var createdAttachment = await _attachmentRepository.CreateAsync(attachmentEntity, cancellationToken);
            
            
            return _mapper.Map<CreateAttachmentResponse>(createdAttachment);
        }

        public async Task<GetAttachmentResponse> GetAttachmentByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            
            var attachment = await _attachmentRepository.GetByIdAsync(id, cancellationToken);
            
            var response = _mapper.Map<GetAttachmentResponse>(attachment);
            
            return response;
        }

        
        public async Task<bool> DeleteAttachmentByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _attachmentRepository.GetByIdAsync(id, cancellationToken);
            
            var result= await _attachmentRepository.DeleteByIdAsync(id, cancellationToken);
            
            var deleteResult =await _fileService.DeleteFileAsync(entity.FilePath);
            
            if (!deleteResult) return false;
            return result;
        }

        public async Task<List<GetAttachmentResponse>> GetAllAttachmentsAsync(CancellationToken cancellationToken)
        {
            var attachmentEntities = await _attachmentRepository.GetAllListAsync(cancellationToken);
            return _mapper.Map<List<GetAttachmentResponse>>(attachmentEntities);
        }
    }
}

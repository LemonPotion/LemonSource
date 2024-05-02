using AutoMapper;
using LeMail.Application.Dto_s.Attachment.Requests;
using LeMail.Application.Dto_s.Attachment.Responses;
using LeMail.Application.Interfaces.Repository;
using LeMail.Application.Interfaces.Services;
using LeMail.Domain.Entities;
using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Validators.Entities;

namespace LeMail.Application.Services
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IMapper _mapper;

        public AttachmentService(IAttachmentRepository attachmentRepository, IMapper mapper)
        {
            _attachmentRepository = attachmentRepository;
            _mapper = mapper;
        }

        public async Task<CreateAttachmentResponse> CreateAttachmentAsync(CreateAttachmentRequest request, CancellationToken cancellationToken)
        {
            var attachmentEntity = _mapper.Map<Attachment>(request);

            var validator = new AttachmentValidator(nameof(Attachment));
            validator.ValidateWithExceptions(attachmentEntity);

            var createdAttachment = await _attachmentRepository.CreateAsync(attachmentEntity, cancellationToken);
            return _mapper.Map<CreateAttachmentResponse>(createdAttachment);
        }

        public async Task<GetAttachmentResponse> GetAttachmentByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var attachmentEntity = await _attachmentRepository.GetByIdAsync(id, cancellationToken);
            return _mapper.Map<GetAttachmentResponse>(attachmentEntity);
        }

        public async Task<UpdateAttachmentResponse> UpdateAttachmentAsync(UpdateAttachmentRequest request, CancellationToken cancellationToken)
        {
            var attachmentEntity = await _attachmentRepository.GetByIdAsync(request.Id, cancellationToken);
            _mapper.Map(request, attachmentEntity);

            var updatedAttachment = await _attachmentRepository.UpdateAsync(attachmentEntity, cancellationToken);
            return _mapper.Map<UpdateAttachmentResponse>(updatedAttachment);
        }
        
        public async Task<bool> DeleteAttachmentByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _attachmentRepository.DeleteByIdAsync(id, cancellationToken);
        }

        public async Task<List<GetAttachmentResponse>> GetAllAttachmentsAsync(CancellationToken cancellationToken)
        {
            var attachmentEntities = await _attachmentRepository.GetAllListAsync(cancellationToken);
            return _mapper.Map<List<GetAttachmentResponse>>(attachmentEntities);
        }
    }
}

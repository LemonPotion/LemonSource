using AutoMapper;
using LeMail.Application.Dto_s.Reviewer.Requests;
using LeMail.Application.Dto_s.Reviewer.Responses;
using LeMail.Application.Interfaces.Repository;
using LeMail.Application.Interfaces.Services;
using LeMail.Domain.Entities;
using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Validators.Entities;

namespace LeMail.Application.Services;

public class ReviewerService : IReviewerService
{
    private readonly IReviewerRepository _reviewerRepository;
    private readonly IMapper _mapper;
    
    public ReviewerService(IMapper mapper, IReviewerRepository reviewerRepository)
    {
        _mapper = mapper;
        _reviewerRepository = reviewerRepository;
    }
    
    public async Task<CreateReviewerResponse> CreateAsync(CreateReviewerRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Reviewer>(request);
            
        var validator = new ReviewerValidator(nameof(Reviewer));
        validator.ValidateWithExceptions(entity);
            
        var createdEntity = await _reviewerRepository.CreateAsync(entity, cancellationToken);
        return _mapper.Map<CreateReviewerResponse>(createdEntity);
    }

    public async Task<GetReviewerResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _reviewerRepository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<GetReviewerResponse>(entity);
    }

    public async Task<UpdateReviewerResponse> UpdateAsync(UpdateReviewerRequest request, CancellationToken cancellationToken)
    {
        var entity = await _reviewerRepository.GetByIdAsync(request.Id, cancellationToken);
        _mapper.Map(request, entity);
            
        var updatedEntity = await _reviewerRepository.UpdateAsync(entity, cancellationToken);
            
        return _mapper.Map<UpdateReviewerResponse>(updatedEntity);
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _reviewerRepository.DeleteByIdAsync(id, cancellationToken);
    }

    public async Task<List<GetReviewerResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _reviewerRepository.GetAllListAsync(cancellationToken);
        return _mapper.Map<List<GetReviewerResponse>>(entities);
    }
}
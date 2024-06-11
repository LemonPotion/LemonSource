using AutoMapper;
using LeMail.Application.Dto_s.Review.Requests;
using LeMail.Application.Dto_s.Review.Responses;
using LeMail.Application.Interfaces.Repository;
using LeMail.Application.Interfaces.Services;
using LeMail.Domain.Entities;
using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Validators.Entities;

namespace LeMail.Application.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IMapper _mapper;
    
    public ReviewService(IMapper mapper, IReviewRepository reviewRepository)
    {
        _mapper = mapper;
        _reviewRepository = reviewRepository;
    }
    
    public async Task<CreateReviewResponse> CreateAsync(CreateReviewRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Review>(request);
            
        var validator = new ReviewValidator(nameof(Review));
        validator.ValidateWithExceptions(entity);
            
        var createdEntity = await _reviewRepository.CreateAsync(entity, cancellationToken);
        return _mapper.Map<CreateReviewResponse>(createdEntity);
    }

    public async Task<GetReviewResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _reviewRepository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<GetReviewResponse>(entity);
    }

    public async Task<UpdateReviewResponse> UpdateAsync(UpdateReviewRequest request, CancellationToken cancellationToken)
    {
        var entity = await _reviewRepository.GetByIdAsync(request.Id, cancellationToken);
        _mapper.Map(request, entity);
            
        var updatedEntity = await _reviewRepository.UpdateAsync(entity, cancellationToken);
            
        return _mapper.Map<UpdateReviewResponse>(updatedEntity);
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _reviewRepository.DeleteByIdAsync(id, cancellationToken);
    }

    public async Task<List<GetReviewResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _reviewRepository.GetAllListAsync(cancellationToken);
        return _mapper.Map<List<GetReviewResponse>>(entities);
    }
}
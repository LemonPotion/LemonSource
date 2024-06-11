using LeMail.Application.Dto_s.Review.Requests;
using LeMail.Application.Dto_s.Review.Responses;

namespace LeMail.Application.Interfaces.Services;

public interface IReviewService
{
    Task<CreateReviewResponse> CreateAsync(CreateReviewRequest request, CancellationToken cancellationToken);
    Task<GetReviewResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<UpdateReviewResponse> UpdateAsync(UpdateReviewRequest request, CancellationToken cancellationToken);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<GetReviewResponse>> GetAllAsync(CancellationToken cancellationToken);
}
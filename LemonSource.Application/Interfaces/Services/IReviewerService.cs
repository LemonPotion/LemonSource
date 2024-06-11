using LeMail.Application.Dto_s.Reviewer.Requests;
using LeMail.Application.Dto_s.Reviewer.Responses;

namespace LeMail.Application.Interfaces.Services;

public interface IReviewerService
{
    Task<CreateReviewerResponse> CreateAsync(CreateReviewerRequest request, CancellationToken cancellationToken);
    Task<GetReviewerResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<UpdateReviewerResponse> UpdateAsync(UpdateReviewerRequest request, CancellationToken cancellationToken);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<GetReviewerResponse>> GetAllAsync(CancellationToken cancellationToken);
}
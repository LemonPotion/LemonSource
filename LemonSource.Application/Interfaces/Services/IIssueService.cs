using LeMail.Application.Dto_s.Issue.Requests;
using LeMail.Application.Dto_s.Issue.Responses;

namespace LeMail.Application.Interfaces.Services;

public interface IIssueService
{
    Task<CreateIssueResponse> CreateAsync(CreateIssueRequest request, CancellationToken cancellationToken);
    Task<GetIssueResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<UpdateIssueResponse> UpdateAsync(UpdateIssueRequest request, CancellationToken cancellationToken);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<GetIssueResponse>> GetAllAsync(CancellationToken cancellationToken);
}
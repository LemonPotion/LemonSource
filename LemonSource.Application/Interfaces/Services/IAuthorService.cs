using LeMail.Application.Dto_s.Author.Requests;
using LeMail.Application.Dto_s.Author.Responses;
using LeMail.Domain.Entities;

namespace LeMail.Application.Interfaces.Services;

public interface IAuthorService
{
    Task<CreateAuthorResponse> CreateAsync(CreateAuthorRequest request, CancellationToken cancellationToken);
    Task<GetAuthorResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<UpdateAuthorResponse> UpdateAsync(UpdateAuthorRequest request, CancellationToken cancellationToken);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<GetAuthorResponse>> GetAllAsync(CancellationToken cancellationToken);
}
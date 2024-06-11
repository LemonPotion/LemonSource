using LeMail.Application.Dto_s.Article.Requests;
using LeMail.Application.Dto_s.Article.Responses;
using LeMail.Domain.Entities;

namespace LeMail.Application.Interfaces.Services;

public interface IArticleService
{
    Task<CreateArticleResponse> CreateAsync(CreateArticleRequest request, CancellationToken cancellationToken);
    Task<GetArticleResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<UpdateArticleResponse> UpdateAsync(UpdateArticleRequest request, CancellationToken cancellationToken);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<GetArticleResponse>> GetAllAsync(CancellationToken cancellationToken);
}
using AutoMapper;
using LeMail.Application.Dto_s.Article.Requests;
using LeMail.Application.Dto_s.Article.Responses;
using LeMail.Application.Interfaces.Repository;
using LeMail.Application.Interfaces.Services;
using LeMail.Domain.Entities;
using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Validators.Entities;

namespace LeMail.Application.Services;

public class ArticleService : IArticleService
{
    private readonly IArticleRepository _articleRepository;
    private readonly IMapper _mapper;
    
    public ArticleService(IMapper mapper, IArticleRepository articleRepository)
    {
        _mapper = mapper;
        _articleRepository = articleRepository;
    }
    
    public async Task<CreateArticleResponse> CreateAsync(CreateArticleRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Article>(request);
            
        var validator = new ArticleValidator(nameof(Article));
        validator.ValidateWithExceptions(entity);
            
        var createdEntity = await _articleRepository.CreateAsync(entity, cancellationToken);
        return _mapper.Map<CreateArticleResponse>(createdEntity);
    }

    public async Task<GetArticleResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _articleRepository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<GetArticleResponse>(entity);
    }

    public async Task<UpdateArticleResponse> UpdateAsync(UpdateArticleRequest request, CancellationToken cancellationToken)
    {
        var entity = await _articleRepository.GetByIdAsync(request.Id, cancellationToken);
        _mapper.Map(request, entity);
            
        var updatedEntity = await _articleRepository.UpdateAsync(entity, cancellationToken);
            
        return _mapper.Map<UpdateArticleResponse>(updatedEntity);
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _articleRepository.DeleteByIdAsync(id, cancellationToken);
    }

    public async Task<List<GetArticleResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _articleRepository.GetAllListAsync(cancellationToken);
        return _mapper.Map<List<GetArticleResponse>>(entities);
    }
}
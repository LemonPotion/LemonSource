using AutoMapper;
using LeMail.Application.Dto_s.Author.Requests;
using LeMail.Application.Dto_s.Author.Responses;
using LeMail.Application.Interfaces.Repository;
using LeMail.Application.Interfaces.Services;
using LeMail.Domain.Entities;
using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Validators.Entities;

namespace LeMail.Application.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;
    
    public AuthorService(IMapper mapper, IAuthorRepository authorRepository)
    {
        _mapper = mapper;
        _authorRepository = authorRepository;
    }
    
    public async Task<CreateAuthorResponse> CreateAsync(CreateAuthorRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Author>(request);
            
        var validator = new AuthorValidator(nameof(Author));
        validator.ValidateWithExceptions(entity);
            
        var createdEntity = await _authorRepository.CreateAsync(entity, cancellationToken);
        return _mapper.Map<CreateAuthorResponse>(createdEntity);
    }

    public async Task<GetAuthorResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _authorRepository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<GetAuthorResponse>(entity);
    }

    public async Task<UpdateAuthorResponse> UpdateAsync(UpdateAuthorRequest request, CancellationToken cancellationToken)
    {
        var entity = await _authorRepository.GetByIdAsync(request.Id, cancellationToken);
        _mapper.Map(request, entity);
            
        var updatedEntity = await _authorRepository.UpdateAsync(entity, cancellationToken);
            
        return _mapper.Map<UpdateAuthorResponse>(updatedEntity);
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _authorRepository.DeleteByIdAsync(id, cancellationToken);
    }

    public async Task<List<GetAuthorResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _authorRepository.GetAllListAsync(cancellationToken);
        return _mapper.Map<List<GetAuthorResponse>>(entities);
    }
}
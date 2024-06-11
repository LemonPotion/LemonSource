using AutoMapper;
using LeMail.Application.Dto_s.Issue.Requests;
using LeMail.Application.Dto_s.Issue.Responses;
using LeMail.Application.Interfaces.Repository;
using LeMail.Application.Interfaces.Services;
using LeMail.Domain.Entities;
using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Validators.Entities;

namespace LeMail.Application.Services;

public class IssueService : IIssueService
{
    private readonly IIssueRepository _issueRepository;
    private readonly IMapper _mapper;
    
    public IssueService(IMapper mapper, IIssueRepository issueRepository)
    {
        _mapper = mapper;
        _issueRepository = issueRepository;
    }
    
    public async Task<CreateIssueResponse> CreateAsync(CreateIssueRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Issue>(request);
            
        var validator = new IssueValidator(nameof(Issue));
        validator.ValidateWithExceptions(entity);
            
        var createdEntity = await _issueRepository.CreateAsync(entity, cancellationToken);
        return _mapper.Map<CreateIssueResponse>(createdEntity);
    }

    public async Task<GetIssueResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _issueRepository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<GetIssueResponse>(entity);
    }

    public async Task<UpdateIssueResponse> UpdateAsync(UpdateIssueRequest request, CancellationToken cancellationToken)
    {
        var entity = await _issueRepository.GetByIdAsync(request.Id, cancellationToken);
        _mapper.Map(request, entity);
            
        var updatedEntity = await _issueRepository.UpdateAsync(entity, cancellationToken);
            
        return _mapper.Map<UpdateIssueResponse>(updatedEntity);
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _issueRepository.DeleteByIdAsync(id, cancellationToken);
    }

    public async Task<List<GetIssueResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _issueRepository.GetAllListAsync(cancellationToken);
        return _mapper.Map<List<GetIssueResponse>>(entities);
    }
}
using AutoMapper;
using LeMail.Application.Dto_s.Contact.Requests;
using LeMail.Application.Dto_s.Contact.Responses;
using LeMail.Application.Interfaces.Repository;
using LeMail.Application.Interfaces.Services;
using LeMail.Domain.Entities;

namespace LeMail.Application.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;
    private readonly IMapper _mapper;

    public ContactService(IContactRepository contactRepository, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _mapper = mapper;
    }
    
    public async Task<CreateContactResponse> CreateAsync(CreateContactRequest request, CancellationToken cancellationToken)
    {
        var contact = _mapper.Map<Contact>(request);
        var createdContact= await _contactRepository.CreateAsync(contact, cancellationToken);
        var response = _mapper.Map<CreateContactResponse>(createdContact);
        
        return response;
    }

    public async Task<GetContactResponse> GetContactByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var contact = await _contactRepository.GetByIdAsync(id, cancellationToken);
        var response = _mapper.Map<GetContactResponse>(contact);

        return response;
    }

    public async Task<UpdateContactResponse> UpdateContactAsync(UpdateContactRequest request, CancellationToken cancellationToken)
    {
        var contact = await _contactRepository.GetByIdAsync(request.Id, cancellationToken);
        var updatedContact = await _contactRepository.UpdateAsync(contact, cancellationToken);
        var response = _mapper.Map<UpdateContactResponse>(updatedContact);

        return response;
    }

    public async Task<bool> DeleteContactByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _contactRepository.DeleteByIdAsync(id, cancellationToken);
    }

    public async Task<List<GetContactResponse>> GetAllContactsAsync(CancellationToken cancellationToken)
    {
        var contacts = _contactRepository.GetAllListAsync(cancellationToken);
        var response = _mapper.Map<List<GetContactResponse>>(contacts);

        return response;
    }
}
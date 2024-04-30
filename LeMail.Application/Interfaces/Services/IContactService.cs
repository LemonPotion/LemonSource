using LeMail.Application.Dto_s.Contact.Requests;
using LeMail.Application.Dto_s.Contact.Responses;

namespace LeMail.Application.Interfaces.Services;

public interface IContactService
{

    Task<CreateContactResponse> CreateAsync(CreateContactRequest request , CancellationToken cancellationToken);
    Task<GetContactResponse> GetContactByIdAsync(Guid id , CancellationToken cancellationToken);
    Task<UpdateContactResponse> UpdateContactAsync(UpdateContactRequest request, CancellationToken cancellationToken);
    Task<bool> DeleteContactByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<GetContactResponse>> GetAllContactsAsync(CancellationToken cancellationToken);
    Task<List<GetContactResponse>> GetAllContactsByUserId(Guid id, CancellationToken cancellationToken);

}
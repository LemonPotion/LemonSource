namespace LeMail.Application.Dto_s.Contact.Requests;

public class DeleteContactRequest : BaseContactDto
{
    public Guid Id { get; init; }
}
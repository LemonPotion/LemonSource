using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Validators;

namespace LeMail.Domain.Entities;
//TODO: доделать валидации
public class Contact : BaseEntity
{
    public string ContactName { get; set; }
    public string ContactMail { get; set; }
    public string Description { get; set; }
    public User User { get; set; }

    public Contact(Guid id, string contactName, string contactMail , string description, User user)
    {
        var idValidationResult = new IdValidator(nameof(id)).ValidateWithExceptions(id);
        Id = id;
        var contactNameValidationResult = new ContactNameValidator(nameof(contactName)).ValidateWithExceptions(contactName);
        ContactName = contactName;
        var contactMailValidatorResult = new EmailValidator(nameof(contactMail)).ValidateWithExceptions(contactMail);
        ContactMail = contactMail;
        var descriptionValidationResult = new DescriptionValidator(nameof(description)).ValidateWithExceptions(description);
        Description = description;
        var userValidationResult = new UserValidator(nameof(user)).ValidateWithExceptions(user);
        User = user;
    }
}
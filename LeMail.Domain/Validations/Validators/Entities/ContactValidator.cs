using FluentValidation;
using LeMail.Domain.Entities;
using LeMail.Domain.Validations.Validators.Common;

namespace LeMail.Domain.Validations.Validators.Entities;

public class ContactValidator : AbstractValidator<Contact>
{
    public ContactValidator(string paramName)
    {
        RuleFor(param => param.User).SetValidator(new UserObjValidator(paramName));
        RuleFor(param => param.Description).SetValidator(new DescriptionValidator(nameof(Contact.Description)));
        RuleFor(param => param.ContactMail).SetValidator(new EmailValidator(nameof(Contact.ContactMail)));
        RuleFor(param => param.ContactName).SetValidator(new ContactNameValidator(nameof(Contact.ContactName)));
    }
}
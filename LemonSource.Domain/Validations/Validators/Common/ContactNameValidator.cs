using FluentValidation;

namespace LeMail.Domain.Validations.Validators.Common;
/// <summary>
/// Contact name validator
/// </summary>
public class ContactNameValidator: AbstractValidator<string>
{
    public ContactNameValidator(string paramName)
    {
        RuleFor(param => param)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
    }
}
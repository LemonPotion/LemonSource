using FluentValidation;
using LeMail.Domain.Entities;

namespace LeMail.Domain.Validations.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator(string paramName)
    {
        RuleFor(param => param)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
    }
}
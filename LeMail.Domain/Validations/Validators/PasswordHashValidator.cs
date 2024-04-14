using FluentValidation;

namespace LeMail.Domain.Validations.Validators;

public class PasswordHashValidator : AbstractValidator<string>
{
    public PasswordHashValidator(string paramName)
    {
        RuleFor(param => param)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
    }
}
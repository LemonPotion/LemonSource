using FluentValidation;

namespace LeMail.Domain.Validations.Validators.Common;

public class BaseStringValidation : AbstractValidator<string>
{
    public BaseStringValidation(string paramName)
    {
        RuleFor(param => param)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
    }
}
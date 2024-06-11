using FluentValidation;

namespace LeMail.Domain.Validations.Validators.Common;
/// <summary>
/// SaltValidator
/// </summary>
public class SaltValidator : AbstractValidator<string>
{
    public SaltValidator(string paramName)
    {
        RuleFor(param => param)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
    }
}
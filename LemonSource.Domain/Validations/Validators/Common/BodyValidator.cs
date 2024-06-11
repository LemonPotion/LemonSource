using FluentValidation;

namespace LeMail.Domain.Validations.Validators.Common;
/// <summary>
/// Body text validator
/// </summary>
public class BodyValidator : AbstractValidator<string>
{
    public BodyValidator(string paramName)
    {
        RuleFor(param => param)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
    }
}
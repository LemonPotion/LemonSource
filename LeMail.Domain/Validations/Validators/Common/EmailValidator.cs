using FluentValidation;

namespace LeMail.Domain.Validations.Validators.Common;

public class EmailValidator : AbstractValidator<string>
{
    public EmailValidator(string paramName)
    {
        RuleFor(param => param)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName))
            .Matches(RegexPatterns.Email).WithMessage(string.Format(ExceptionMessages.InvalidEmailFormat, paramName));
    }
}
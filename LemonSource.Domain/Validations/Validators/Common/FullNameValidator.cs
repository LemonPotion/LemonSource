using FluentValidation;
using LeMail.Domain.ValueObjects;

namespace LeMail.Domain.Validations.Validators.Common;

/// <summary>
/// Fullname class validator
/// </summary>
public class FullNameValidator: AbstractValidator<FullName>
{
    public FullNameValidator(string paramName)
    {
        RuleFor(param => param.FirstName)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName))
            .Matches(RegexPatterns.FullName).WithMessage(string.Format(ExceptionMessages.InvalidNameFormat, paramName));
        
        RuleFor(param => param.MiddleName)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName))
            .Matches(RegexPatterns.FullName).WithMessage(string.Format(ExceptionMessages.InvalidNameFormat, paramName))
            .When(param=> param is not null);
        
        RuleFor(param => param.LastName)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName))
            .Matches(RegexPatterns.FullName).WithMessage(string.Format(ExceptionMessages.InvalidNameFormat, paramName));
    }
}
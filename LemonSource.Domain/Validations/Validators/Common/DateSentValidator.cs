using FluentValidation;

namespace LeMail.Domain.Validations.Validators.Common;
/// <summary>
/// Sent date validator
/// </summary>
public class DateSentValidator : AbstractValidator<DateTime>
{
    public DateSentValidator(string paramName)
    {
        RuleFor(param => param)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
    }
}
using FluentValidation;

namespace LeMail.Domain.Validations.Validators;

public class DateSentValidator : AbstractValidator<DateTime>
{
    public DateSentValidator(string paramName)
    {
        RuleFor(param => param)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
    }
}
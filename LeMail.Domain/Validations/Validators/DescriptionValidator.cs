using FluentValidation;

namespace LeMail.Domain.Validations.Validators;

public class DescriptionValidator: AbstractValidator<string>
{
    public DescriptionValidator(string paramName)
    {
        RuleFor(param => param)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
    }
}
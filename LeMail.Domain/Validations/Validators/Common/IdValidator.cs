using FluentValidation;

namespace LeMail.Domain.Validations.Validators.Common;

public class IdValidator : AbstractValidator<Guid>
{
    public IdValidator(string paramName)
    {
        RuleFor(param => param)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
    }
}
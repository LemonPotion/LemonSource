using FluentValidation;

namespace LeMail.Domain.Validations.Validators.Common;

public class SubjectValidator : AbstractValidator<string>
{
    public SubjectValidator(string paramName)
    {
        RuleFor(param => param)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
    }
}
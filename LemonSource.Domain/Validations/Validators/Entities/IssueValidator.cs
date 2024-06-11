using FluentValidation;
using LeMail.Domain.Entities;

namespace LeMail.Domain.Validations.Validators.Entities;

public class IssueValidator : AbstractValidator<Issue>
{
    public IssueValidator(string paramName)
    {
        RuleFor(param => param.Title).NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
        RuleFor(param => param.Description).NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
    }
}
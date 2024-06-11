using FluentValidation;
using LeMail.Domain.Entities;
using LeMail.Domain.Validations.Validators.Common;

namespace LeMail.Domain.Validations.Validators.Entities;

public class ReviewValidator : AbstractValidator<Review>
{
    public ReviewValidator(string paramName)
    {
        RuleFor(param => param.Title).NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
        RuleFor(param=> param.Description).NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
        RuleFor(param=> param.Objective).NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
    }
}
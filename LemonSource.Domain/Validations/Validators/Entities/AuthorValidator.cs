using FluentValidation;
using LeMail.Domain.Entities;

namespace LeMail.Domain.Validations.Validators.Entities;

public class AuthorValidator : AbstractValidator<Author>
{
    public AuthorValidator(string paramName)
    {
        RuleFor(param => param.NickName).NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
        RuleFor(param => param.FullName)
            .NotEmpty().When(param => param is not null).WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
    }
}
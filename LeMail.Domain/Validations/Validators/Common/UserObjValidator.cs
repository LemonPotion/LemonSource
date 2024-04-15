using FluentValidation;
using LeMail.Domain.Entities;

namespace LeMail.Domain.Validations.Validators.Common;

public class UserObjValidator : AbstractValidator<User>
{
    public UserObjValidator(string paramName)
    {
        RuleFor(param => param)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
    }
}
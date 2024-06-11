using FluentValidation;
using LeMail.Domain.Entities;

namespace LeMail.Domain.Validations.Validators.Common;
/// <summary>
/// User object validator
/// </summary>
public class UserObjValidator : AbstractValidator<User>
{
    public UserObjValidator(string paramName)
    {
        RuleFor(param => param)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
    }
}
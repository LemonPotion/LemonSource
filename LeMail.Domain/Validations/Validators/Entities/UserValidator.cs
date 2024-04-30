using FluentValidation;
using LeMail.Domain.Entities;
using LeMail.Domain.Validations.Primitives;
using LeMail.Domain.Validations.Validators.Common;

namespace LeMail.Domain.Validations.Validators.Entities;
/// <summary>
/// User entity validator
/// </summary>
public class UserValidator : AbstractValidator<User>
{
    public UserValidator(string paramName)
    {
        RuleFor(param => param).NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName));
        RuleFor(param => param.Role).SetValidator(new EnumValidator<Role>(nameof(User.Role)));
        RuleFor(param => param.Email).SetValidator(new EmailValidator(nameof(User.Email)));
        RuleFor(param => param.Password).SetValidator(new PasswordHashValidator(nameof(User.Password)));
        RuleFor(param => param.FullName).SetValidator(new FullNameValidator(nameof(User.FullName)));
    }
}

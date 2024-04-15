using FluentValidation;
using LeMail.Domain.Entities;
using LeMail.Domain.Validations.Primitives;
using LeMail.Domain.Validations.Validators.Common;

namespace LeMail.Domain.Validations.Validators.Entities;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator(string paramName)
    {
        RuleFor(param => param.Id).SetValidator(new IdValidator(nameof(User.Id)));
        RuleFor(param => param.Role).SetValidator(new EnumValidator<Role>(nameof(User.Role)));
        RuleFor(param => param.Email).SetValidator(new EmailValidator(nameof(User.Email)));
        RuleFor(param => param.Salt).SetValidator(new SaltValidator(nameof(User.Salt)));
        RuleFor(param => param.PasswordHash).SetValidator(new PasswordHashValidator(nameof(User.PasswordHash)));
        RuleFor(param => param.FullName).SetValidator(new FullNameValidator(nameof(User.FullName)));
    }
}

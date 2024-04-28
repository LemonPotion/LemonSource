using FluentValidation;

namespace LeMail.Domain.Validations.Validators.Common;

public class EnumValidator<TEnum> : AbstractValidator<TEnum> where TEnum : Enum
{
    /// <summary>
    /// Валидация enum 
    /// </summary>
    /// <param name="paramName"></param>
    /// <param name="defaultValues"></param>
    public EnumValidator(string paramName, params TEnum[] defaultValues)
    {
        RuleFor(param => param)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName));
        
        foreach (var value in defaultValues)
        {
            RuleFor(param => param)
                .Must(val => !val.Equals(value)).WithMessage(string.Format(ExceptionMessages.DefaultEnum, paramName));
        }
    }
}
using FluentValidation;

namespace LeMail.Domain.Validations;

public static class ValidationExtensions
{
    public static T ValidateWithExceptions<T> ( this IValidator<T> validator, T value)
    {
        var validationResult = validator.Validate(value);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        return value;
    }
}
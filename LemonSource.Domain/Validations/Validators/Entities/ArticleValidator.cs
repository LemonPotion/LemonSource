using FluentValidation;
using LeMail.Domain.Entities;

namespace LeMail.Domain.Validations.Validators.Entities;

public class ArticleValidator : AbstractValidator<Article>
{
    public ArticleValidator(string paramName)
    {
        RuleFor(param => param.Rating).NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
        RuleFor(param => param.Link)
            .NotEmpty().When(param => param is not null).WithMessage(string.Format(ExceptionMessages.EmptyError, paramName))
            .Matches(RegexPatterns.Link).When(param => param is not null).WithMessage(string.Format(ExceptionMessages.InvalidEmailFormat, paramName));
        RuleFor(param => param.Title).NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
        RuleFor(param => param.Objective).NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
        
    }
}
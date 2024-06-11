using FluentValidation;
using LeMail.Domain.Entities;
using LeMail.Domain.Validations.Validators.Common;

namespace LeMail.Domain.Validations.Validators.Entities;

public class ReviewerValidator : AbstractValidator<Reviewer>
{
    public ReviewerValidator( string paramName)
    {
        RuleFor(param => param.FullName).SetValidator(new FullNameValidator(nameof(Reviewer.FullName)));
        
    }
}
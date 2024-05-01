using FluentValidation;
using LeMail.Domain.Entities;
using LeMail.Domain.Validations.Validators.Common;

namespace LeMail.Domain.Validations.Validators.Entities;

public class AttachmentValidator : AbstractValidator<Attachment>
{
    public AttachmentValidator(string paramName)
    {
        RuleFor(param => param.FileName).SetValidator(new BaseStringValidation(paramName));
        RuleFor(param => param.FilePath).SetValidator(new BaseStringValidation(paramName));
        RuleFor(param => param.FileType).SetValidator(new BaseStringValidation(paramName));
    }
}
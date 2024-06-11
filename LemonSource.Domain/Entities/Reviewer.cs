using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Validators.Entities;
using LeMail.Domain.ValueObjects;

namespace LeMail.Domain.Entities;

public class Reviewer : BaseEntity
{
    public FullName FullName { get; set; }
    public string? Degree { get; set; }
    
    public ICollection<Review> Reviews { get; set; }

    public Reviewer()
    {
        var validator = new ReviewerValidator(nameof(Reviewer));
        validator.ValidateWithExceptions(this);
    }

    public void Update(FullName fullName, string degree)
    {
        FullName.Update(fullName);
        Degree = degree;
    }
}
using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Validators.Common;

namespace LeMail.Domain.ValueObjects;
/// <summary>
/// Fullname class
/// </summary>
public class FullName: BaseValueObject
{

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; } = null;

    public FullName(string firstName, string lastName, string middleName)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        var validator = new FullNameValidator(nameof(FullName));
        validator.ValidateWithExceptions(this);
    }

    /// <summary>
    /// Update Fullname entity method
    /// </summary>
    /// <param name="fullName"></param>
    public void Update(FullName fullName)
    {
        FirstName = fullName.FirstName;
        LastName = fullName.LastName;
        MiddleName = fullName.MiddleName;
    }
}
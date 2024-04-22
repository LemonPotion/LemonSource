namespace LeMail.Domain.ValueObjects;

public class FullName: BaseValueObject
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; } = null;

    public FullName(string firstName, string lastName, string? middleName)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
    }

    public FullName Update(string firstName, string lastName, string middleName)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        return this;
    }
}
namespace LeMail.Application.Dto_s.User;

public class FullNameDto
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string? MiddleName { get; init; } = null;
}
using LeMail.Domain.Validations.Primitives;

namespace LeMail.Application.Dto_s.User;

public class BaseUserDto
{
    public Role Role { get; init; }
    public string Email { get; init; }
    public string Salt { get; init; }
    public string PasswordHash { get; init; }
    public FullNameDto FullName { get; init; }
}
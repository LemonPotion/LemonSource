using LeMail.Domain.Primitives;
using LeMail.Domain.ValueObjects;

namespace LeMail.Domain.Entities;

public class User : BaseEntity
{
    public Role Role { get; set; }
    public string Email { get; set; }
    public string Salt { get; set; }
    public string PasswordHash { get; set; }
    public FullName FullName { get; set; }
    
    public User(Guid id, Role role, string email, string salt, string passwordHash, FullName fullName)
    {
        Email = email;
        Salt = salt;
        PasswordHash = passwordHash;
        FullName = fullName;
    }
}
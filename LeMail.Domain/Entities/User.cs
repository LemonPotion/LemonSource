using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Primitives;
using LeMail.Domain.Validations.Validators;
using LeMail.Domain.ValueObjects;

namespace LeMail.Domain.Entities;

public class User : BaseEntity
{
    public Role Role { get; set; }
    public string Email { get; set; }
    public string Salt { get; set; }
    public string PasswordHash { get; set; }
    public FullName FullName { get; set; }
    
    public ICollection<Message> Messages { get; set; }
    public ICollection<Contact> Contacts { get; set; }
    
    public User(Guid id, Role role, string email, string salt, string passwordHash, FullName fullName)
    {
        var idValidationResult = new IdValidator(nameof(id)).ValidateWithExceptions(id);
        Id = id;
        var roleValidationResult = new EnumValidator<Role>(nameof(role), [Role.None]).ValidateWithExceptions(role);
        Role = role;
        var emailValidationResult = new EmailValidator(nameof(email)).ValidateWithExceptions(email);
        Email = email;
        var saltValidation = new SaltValidator(nameof(salt)).ValidateWithExceptions(salt);
        Salt = salt;
        var passwordHashValidationResult = new PasswordHashValidator(nameof(passwordHash)).ValidateWithExceptions(salt);
        PasswordHash = passwordHash;
        var fullNameValidationResult = new FullNameValidator(nameof(fullName)).ValidateWithExceptions(fullName);
        FullName = fullName;
    }
}
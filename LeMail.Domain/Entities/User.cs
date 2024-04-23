using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Primitives;
using LeMail.Domain.Validations.Validators.Entities;
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

    public User()
    {
        var validator = new UserValidator(nameof(User));

        validator.ValidateWithExceptions(this);
    }

    public void Update(string email, string firstName, string lastName, string middleName)
    {
        FullName.Update(firstName, lastName, middleName);
        Email = email;
        
    }
}
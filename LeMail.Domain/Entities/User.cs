using LeMail.Domain.Validations.Primitives;
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
    
    public User(string email, string salt, string passwordHash, FullName fullName, ICollection<Message> messages, ICollection<Contact> contacts)
    {
        Email = email;
        Salt = salt;
        PasswordHash = passwordHash;
        FullName = fullName;
        Messages = messages;
        Contacts = contacts;
    }
}
using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Primitives;
using LeMail.Domain.Validations.Validators.Entities;
using LeMail.Domain.ValueObjects;
using System.Security.Cryptography;

namespace LeMail.Domain.Entities;
/// <summary>
/// User Entity
/// </summary>
public class User : BaseEntity
{
    /// <summary>
    /// Role enum
    /// </summary>
    public Role Role { get; set; }
    /// <summary>
    /// Email adress
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// User password
    /// </summary>
    public string Password { get; set; }
    /// <summary>
    /// User fullname 
    /// </summary>
    public FullName FullName { get; set; }
    
    public DateTime CreateDate { get; set; } = DateTime.Today; 
    public ICollection<Article> Articles { get; set; }

    public User()
    {
        var validator = new UserValidator(nameof(User));
        validator.ValidateWithExceptions(this);
        
    }
    
    /// <summary>
    /// Update User entity method
    /// </summary>
    /// <param name="email"></param>
    /// <param name="fullName"></param>
    public void Update(string email, FullName fullName)
    {
        FullName.Update(fullName);
        Email = email;
        var validator = new UserValidator(nameof(User));

        validator.ValidateWithExceptions(this);
    }
}
using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Validators.Entities;

namespace LeMail.Domain.Entities;
public class Contact : BaseEntity
{
    public string ContactName { get; set; }
    public string ContactMail { get; set; }
    public string Description { get; set; }
    public User User { get; set; }

    public Guid UserId { get; set; } // Foreign key
    
    // Добавьте конструктор без параметров
    public Contact()
    {
        var validator = new ContactValidator(nameof(Contact));
        validator.ValidateWithExceptions(this);
    }
    
    public void Update(string contactName, string contactMail, string description)
    {
        ContactName = contactName;
        ContactMail = contactMail;
        Description = description;
        var validator = new ContactValidator(nameof(Contact));
        validator.ValidateWithExceptions(this);
    }
}

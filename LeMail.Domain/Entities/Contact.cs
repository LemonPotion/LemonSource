using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Validators.Entities;

namespace LeMail.Domain.Entities;
/// <summary>
/// Contact entity
/// </summary>
public class Contact : BaseEntity
{
    /// <summary>
    /// name of contact
    /// </summary>
    public string ContactName { get; set; }
    /// <summary>
    /// contact email address
    /// </summary>
    public string ContactMail { get; set; }
    /// <summary>
    /// description of contact
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Navigation property
    /// </summary>
    public User User { get; set; }
    /// <summary>
    /// Foreign key
    /// </summary>
    public Guid UserId { get; set; }
    public Contact()
    {
        var validator = new ContactValidator(nameof(Contact));
        validator.ValidateWithExceptions(this);
    }
    /// <summary>
    /// Update Contact entity method
    /// </summary>
    /// <param name="contactName"></param>
    /// <param name="contactMail"></param>
    /// <param name="description"></param>
    public void Update(string contactName, string contactMail, string description)
    {
        ContactName = contactName;
        ContactMail = contactMail;
        Description = description;
        var validator = new ContactValidator(nameof(Contact));
        validator.ValidateWithExceptions(this);
    }
}

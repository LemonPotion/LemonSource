using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Validators.Entities;

namespace LeMail.Domain.Entities;
/// <summary>
/// Message Entity
/// </summary>
public class Message : BaseEntity
{
    /// <summary>
    /// Navigation property
    /// </summary>
    public User User { get; init; }
    /// <summary>
    /// Foreign key
    /// </summary>
    public Guid UserId { get; init; } 

    /// <summary>
    /// Email subject
    /// </summary>
    public string Subject { get; set; }
    /// <summary>
    /// Email body text
    /// </summary>
    public string Body { get; set; }
    /// <summary>
    /// Address email
    /// </summary>
    public string To { get; set; }
    /// <summary>
    /// Send date
    /// </summary>
    public DateTime DateSent { get; set; } = DateTime.Now;

    // Добавьте конструктор без параметров
    public Message()
    {
        var validator = new MessageValidator(nameof(Message));
        validator.ValidateWithExceptions(this);
    }
    /// <summary>
    /// Update Message entity method
    /// </summary>
    /// <param name="subject"></param>
    /// <param name="body"></param>
    public void Update(string subject, string body)
    {
        Subject = subject;
        Body = body;
        DateSent = DateTime.Now;
        var validator = new MessageValidator(nameof(Message));
        validator.ValidateWithExceptions(this);
    }
}

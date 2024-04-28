using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Validators.Entities;

namespace LeMail.Domain.Entities;

public class Message : BaseEntity
{
    public User User { get; set; } // Navigation property
    public Guid UserId { get; set; } // Foreign key

    public string Subject { get; set; }
    public string Body { get; set; }
    
    public string To { get; set; }
    public DateTime DateSent { get; set; } = DateTime.Now;

    // Добавьте конструктор без параметров
    public Message()
    {
        var validator = new MessageValidator(nameof(Message));
        validator.ValidateWithExceptions(this);
    }
    public void Update(string subject, string body)
    {
        Subject = subject;
        Body = body;
        DateSent = DateTime.Now;
        var validator = new MessageValidator(nameof(Message));
        validator.ValidateWithExceptions(this);
    }
}

namespace LeMail.Domain.Entities;

public class Message : BaseEntity
{
    public User User { get; set; } // Navigation property
    public Guid UserId { get; set; } // Foreign key

    public string Subject { get; set; }
    public string Body { get; set; }
    public DateTime DateSent { get; set; }

    // Добавьте конструктор без параметров
    public Message() { }

    // Измените ваш текущий конструктор
    public Message(Guid id, User user, DateTime dateSent, string subject, string body)
    {
        Id = id;
        User = user;
        UserId = user.Id; // Assign the foreign key
        Subject = subject;
        Body = body; 
        DateSent = dateSent;
    }
}

namespace LeMail.Domain.Entities;
//TODO: доделать валидации
public class Contact : BaseEntity
{
    public string ContactName { get; set; }
    public string ContactMail { get; set; }
    public string Description { get; set; }
    public User User { get; set; }

    public Guid UserId { get; set; } // Foreign key
    
    // Добавьте конструктор без параметров
    public Contact() { }

    // Измените ваш текущий конструктор
    public Contact(Guid id, string contactName, string contactMail , string description, User user)
    {
        Id = id;
        ContactName = contactName;
        ContactMail = contactMail;
        Description = description;
        User = user;
        UserId = user.Id;
    }
}

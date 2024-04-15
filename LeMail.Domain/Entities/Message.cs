namespace LeMail.Domain.Entities;

public class Message: BaseEntity
{
    public User User { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public DateTime DateSent { get; set; }

    public Message(Guid id,User user,DateTime dateSent ,string subject, string body)
    {
        Id = id;
        User = user;
        Subject = subject;
        Body = body; 
        DateSent = dateSent;
    }
    
}
namespace LeMail.Domain.Entities;

public class Token : BaseEntity
{
    public string Key { get; set; } 
    public DateTime ExpirationDate { get; set; }
    public User User { get; set; }

    public Token(Guid id, string key, DateTime expirationDate, User user)
    {
        
        Id = id;
        Key = key;
        ExpirationDate = expirationDate;
        User = user;
    }
}

using LeMail.Domain.ValueObjects;

namespace LeMail.Domain.Entities;

public class Author : BaseEntity
{
    public string NickName { get; set; }
    public string? Degree { get; set; }
    public FullName? FullName { get; set; }
    
    public ICollection<Article> Articles { get; set; }
    
    public void Update(string nickName, string degree)
    {
        NickName = nickName;
        Degree = degree;
    }
}
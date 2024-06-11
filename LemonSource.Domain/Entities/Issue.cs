namespace LeMail.Domain.Entities;

public class Issue : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }

    public ICollection<Review> Reviews { get; set; }
    
    public void Update(string title, string description)
    {
        Title = title;
        Description = description;
    }
}
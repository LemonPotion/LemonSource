namespace LeMail.Domain.Entities;

public class Article : BaseEntity
{
    public int Rating { get; set; } = 0;
    public string? Link { get; set; }

    public string Title { get; set; }
    public string Objective { get; set; }
    public string? Genre { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Today;
    public int Views { get; set; } = 0;
    
    // Navigation properties
    public Attachment? Attachment { get; set; }
    public ICollection<User> Users { get; set; }
    public Author? Author { get; set; }
    
    public Review? Reviews { get; set; }
    
    public void Update(int rating, string link, string title, string objective, string genre, int views)
    {
        Rating = rating;
        Link = link;
        Title = title;
        Objective = objective;
        Genre = genre;
        Views = views;
    }
}
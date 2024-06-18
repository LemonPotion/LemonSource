namespace LeMail.Domain.Entities;

public class Article : BaseEntity
{
    public int Rating { get; set; } = 0;
    public string? Link { get; set; }

    public string Title { get; set; }
    public string Objective { get; set; }
    public string? Genre { get; set; }
    
    public Guid AttachmentId { get; set; }
    public int Views { get; set; } = 0;
    
    // Navigation properties
    public Attachment? Attachment { get; set; }
    public User  User { get; set; }
    public Guid UserId { get; set; }
    public Author? Author { get; set; }
    
    public Guid AuthorId { get; set; }
    public ICollection<Review>? Reviews { get; set; }
    public Guid ReviewId { get; set; }
    
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
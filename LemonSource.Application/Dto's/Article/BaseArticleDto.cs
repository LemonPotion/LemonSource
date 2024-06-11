namespace LeMail.Application.Dto_s.Article;

public class BaseArticleDto
{
    public string? Link { get; set; }

    public string Title { get; set; }
    public string Objective { get; set; }
    public string? Genre { get; set; }
    
    public Guid? ReviewId { get; set; }
    public Guid? AttachmentId { get; set; }
    public Guid UserId { get; set; }
    public Guid? AuthorId { get; set; }
    
}
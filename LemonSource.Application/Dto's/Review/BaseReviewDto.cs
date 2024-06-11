namespace LeMail.Application.Dto_s.Review;

public class BaseReviewDto
{
    public string Title { get; set; }
    public string Objective { get; set; }
    public string Description { get; set; }
    
    public Guid IssueId { get; set; }
    public Guid ReviewerId { get; set; }
}
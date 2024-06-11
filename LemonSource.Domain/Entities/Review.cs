namespace LeMail.Domain.Entities;

public class Review : BaseEntity
{
    public string Title { get; set; }
    public string Objective { get; set; }
    public string Description { get; set; }
    

    
    public ICollection<Article> Articles { get; set; }


    // Navigation properties
    public Issue Issue { get; set; }
    public Reviewer Reviewer { get; set; }

    public void Update(string title, string objective, string description)
    {
        Title = title;
        Objective = objective;
        Description = description;
    }
}
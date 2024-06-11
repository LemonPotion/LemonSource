using LeMail.Domain.Entities;
using LeMail.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace LeMail.Persistence;
/// <summary>
/// Database context class 
/// </summary>
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }
    
    /// <summary>
    /// User entity DbSet
    /// </summary>
    public DbSet<User> Users { get; set; }
    
    public DbSet<Reviewer> Reviewers { get; set; }
    
    public DbSet<Review> Reviews { get; set; }
    
    public DbSet<Issue> Issues { get; set; }
    
    public DbSet<Author> Authors { get; set; }
    
    public DbSet<Attachment> Attachments { get; set; }
    
    public DbSet<Article> Articles { get; set; }
    
    /// <summary>
    /// Applying configurations 
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new AttachmentConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewerConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewConfiguration());
        modelBuilder.ApplyConfiguration(new IssueConfiguration());
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new ArticleConfiguration());
    }
}
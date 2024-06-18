using LeMail.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeMail.Persistence.EntityTypeConfiguration;

/// <summary>
/// Article entity configuration
/// </summary>
public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
       builder.HasKey(article => article.Id).HasName("articleId");
        builder.Property(article => article.Title).HasMaxLength(250).IsRequired().HasColumnName("title");
        builder.Property(article => article.Objective).HasMaxLength(1000).IsRequired().HasColumnName("objective");
        builder.Property(article => article.Genre).HasMaxLength(250).HasColumnName("genre");
        builder.Property(article => article.Link).HasMaxLength(500).HasColumnName("link");
        builder.Property(article => article.Rating).IsRequired().HasDefaultValue(0).HasColumnName("rating");
        builder.Property(article => article.Views).IsRequired().HasDefaultValue(0).HasColumnName("views");

        builder.HasOne(x => x.Attachment)
            .WithMany(x => x.Articles)
            .HasForeignKey(x => x.AttachmentId);

        builder.HasOne(x => x.Author)
            .WithMany(x => x.Articles)
            .HasForeignKey(x => x.AuthorId);

        builder.HasMany<Review>(x => x.Reviews)
            .WithOne(x => x.Article)
            .HasForeignKey(x => x.ArticleId);
        
        builder.HasOne(x => x.User)
            .WithMany(x => x.Articles)
            .HasForeignKey(x => x.UserId);
    }
}
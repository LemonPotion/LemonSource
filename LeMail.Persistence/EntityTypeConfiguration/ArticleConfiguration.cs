using LeMail.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeMail.Persistence.EntityTypeConfiguration;
//TODO: сделать конфигурации вручную (нормальные)
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
        builder.Property(article => article.CreateDate).IsRequired().HasDefaultValue(DateTime.Today)
            .HasColumnName("createDate");

        builder.HasOne<Attachment>(x => x.Attachment)
            .WithMany(x => x.Articles)
            .HasForeignKey(x=> x.Id);

        builder.HasOne<Author>(x => x.Author)
            .WithMany(x => x.Articles)
            .HasForeignKey(x => x.Id);

        builder.HasOne<Review>(x => x.Reviews)
            .WithMany(x => x.Articles)   
            .HasForeignKey(x => x.Id);
    }
}
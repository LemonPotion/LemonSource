using LeMail.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeMail.Persistence.EntityTypeConfiguration;

/// <summary>
/// Review entity configuration
/// </summary>
public class ReviewConfiguration : IEntityTypeConfiguration<Review> 
{
    public void Configure(EntityTypeBuilder<Review> builder) 
    {
        builder.HasKey(review => review.Id).HasName("reviewId");
        builder.Property(review => review.Title).HasMaxLength(250).IsRequired().HasColumnName("title");
        builder.Property(review => review.Objective).HasMaxLength(1000).IsRequired().HasColumnName("objective");
        builder.Property(review => review.Description).HasMaxLength(5000).IsRequired().HasColumnName("description");

        builder.HasOne<Issue>(x => x.Issue)
            .WithMany(x => x.Reviews)
            .HasForeignKey(x=>x.Id);
        
        builder.HasOne<Reviewer>(x => x.Reviewer)
            .WithMany(x => x.Reviews)
            .HasForeignKey(x=>x.Id);
    }
}
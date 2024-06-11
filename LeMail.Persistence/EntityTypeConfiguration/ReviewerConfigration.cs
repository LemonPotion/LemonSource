using LeMail.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeMail.Persistence.EntityTypeConfiguration;

/// <summary>
/// Reviewer entity configuration
/// </summary>
public class ReviewerConfiguration : IEntityTypeConfiguration<Reviewer> 
{
    public void Configure(EntityTypeBuilder<Reviewer> builder) 
    {
        builder.HasKey(reviewer => reviewer.Id).HasName("reviewerId");
        builder.Property(reviewer => reviewer.Degree).HasMaxLength(250).HasColumnName("degree");
        
        builder.OwnsOne(reviewer => reviewer.FullName)
            .Property(name => name.FirstName).HasColumnName("firstName");
        builder.OwnsOne(reviewer => reviewer.FullName)
            .Property(name => name.LastName).HasColumnName("lastName");
        builder.OwnsOne(reviewer => reviewer.FullName)
            .Property(name => name.MiddleName).HasColumnName("middleName");
        
    }
}
using LeMail.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeMail.Persistence.EntityTypeConfiguration;

/// <summary>
/// Issue entity configuration
/// </summary>
public class IssueConfiguration : IEntityTypeConfiguration<Issue> 
{
    public void Configure(EntityTypeBuilder<Issue> builder) 
    {
        builder.HasKey(issue => issue.Id).HasName("issueId");
        builder.Property(issue => issue.Title).HasMaxLength(250).IsRequired().HasColumnName("title");
        builder.Property(issue => issue.Description).HasMaxLength(5000).IsRequired().HasColumnName("description");
    }
}
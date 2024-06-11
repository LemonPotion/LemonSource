using LeMail.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeMail.Persistence.EntityTypeConfiguration;

/// <summary>
/// Author entity configuration
/// </summary>
public class AuthorConfiguration : IEntityTypeConfiguration<Author> 
{
    public void Configure(EntityTypeBuilder<Author> builder) 
    {
        builder.HasKey(author => author.Id).HasName("authorId");
        builder.Property(author => author.NickName).HasMaxLength(250).IsRequired().HasColumnName("nickName");
        builder.Property(author => author.Degree).HasMaxLength(250).HasColumnName("degree");

        builder.OwnsOne(author => author.FullName, fullNameBuilder =>
        {
            fullNameBuilder.Property(name => name.FirstName).HasColumnName("firstName");
            fullNameBuilder.Property(name => name.LastName).HasColumnName("lastName");
            fullNameBuilder.Property(name => name.MiddleName).HasColumnName("middleName");
        });
    }
}
using LeMail.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace LeMail.Persistence.EntityTypeConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User> 
{
    public void Configure(EntityTypeBuilder<User> builder) 
    {
        builder.HasKey(user => user.Id);
        builder.HasIndex(user => user.Id).IsUnique();
        builder.Property(user => user.Email).HasMaxLength(250).IsRequired();
        builder.Property(user => user.Salt).HasMaxLength(250).IsRequired();
        builder.Property(user => user.PasswordHash).HasMaxLength(250).IsRequired();
        builder.OwnsOne(user => user.FullName);
            
        builder.HasMany(user => user.Messages)
            .WithOne(message => message.User)
            .HasForeignKey(message => message.User);
            
        builder.HasMany(user => user.Contacts)
            .WithOne(contact => contact.User)
            .HasForeignKey(contact => contact.User)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}
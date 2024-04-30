using LeMail.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeMail.Persistence.EntityTypeConfiguration
{
    /// <summary>
    /// User entity configuration
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User> 
    {
        public void Configure(EntityTypeBuilder<User> builder) 
        {
            builder.HasKey(user => user.Id).HasName("userId");
            builder.Property(user => user.Email).HasMaxLength(250).IsRequired().HasColumnName("email");
            builder.Property(user => user.Password).HasMaxLength(250).IsRequired().HasColumnName("password");
            builder.OwnsOne(user => user.FullName)
                .Property(name=> name.FirstName).HasColumnName("firstName");
            builder.OwnsOne(user => user.FullName)
                .Property(name=> name.LastName).HasColumnName("lastName");
            builder.OwnsOne(user => user.FullName)
                .Property(name=> name.MiddleName).HasColumnName("middleName");
            
            
            builder.HasMany(user => user.Messages)
                .WithOne(message => message.User)
                .HasForeignKey(message => message.UserId);
                
            builder.HasMany(user => user.Contacts)
                .WithOne(contact => contact.User)
                .HasForeignKey(contact => contact.UserId); 
        }
    }
}

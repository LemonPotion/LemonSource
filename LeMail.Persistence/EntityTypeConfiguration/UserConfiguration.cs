using LeMail.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeMail.Persistence.EntityTypeConfiguration
{
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
            
            // Указываем отношение один ко многим между User и Message
            builder.HasMany(user => user.Messages)
                .WithOne(message => message.User) // Указываем навигационное свойство в Message
                .HasForeignKey(message => message.UserId) // Указываем внешний ключ
                .OnDelete(DeleteBehavior.Cascade); 
                
            builder.HasMany(user => user.Contacts)
                .WithOne(contact => contact.User)
                .HasForeignKey(contact => contact.UserId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}

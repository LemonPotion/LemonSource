using LeMail.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeMail.Persistence.EntityTypeConfiguration;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasKey(message => message.Id);
        builder.HasIndex(message => message.Id).IsUnique();
        builder.Property(message => message.Subject).HasMaxLength(255).IsRequired();
        builder.Property(message => message.Body).IsRequired();
        builder.Property(message => message.DateSent).IsRequired();
    }
}
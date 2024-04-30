using LeMail.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeMail.Persistence.EntityTypeConfiguration;
/// <summary>
/// Message entity configuration
/// </summary>
public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasKey(message => message.Id).HasName("messageId");
        builder.Property(message => message.Subject).HasMaxLength(255).IsRequired().HasColumnName("subject");
        builder.Property(message => message.Body).IsRequired().HasColumnName("body");
        builder.Property(message => message.DateSent).IsRequired().HasColumnName("dateSent");
        builder.Property(message => message.To).IsRequired().HasColumnName("to");
    }
}
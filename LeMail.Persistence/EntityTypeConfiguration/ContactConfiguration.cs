using LeMail.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeMail.Persistence.EntityTypeConfiguration;
/// <summary>
/// Contact entity configuration
/// </summary>
public class ContactConfiguration: IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(contact => contact.Id).HasName("contactId");
        builder.Property(contact => contact.ContactMail).HasMaxLength(250).IsRequired().HasColumnName("contactMail");
        builder.Property(contact => contact.ContactName).HasMaxLength(250).IsRequired().HasColumnName("contactName");
        builder.Property(contact => contact.Description).HasMaxLength(1000).HasColumnName("description");
    }
}
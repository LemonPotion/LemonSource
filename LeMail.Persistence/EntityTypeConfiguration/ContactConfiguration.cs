using LeMail.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeMail.Persistence.EntityTypeConfiguration;

//TODO: поменять как посоветовали все конфиги
public class ContactConfiguration: IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(contact => contact.Id);
        builder.HasIndex(contact => contact.Id).IsUnique();
        builder.Property(contact => contact.ContactMail).HasMaxLength(250).IsRequired();
        builder.Property(contact => contact.ContactName).HasMaxLength(250).IsRequired();
        builder.Property(contact => contact.Description).HasMaxLength(1000);
    }
}
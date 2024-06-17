using LeMail.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeMail.Persistence.EntityTypeConfiguration;

public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
{
    public void Configure(EntityTypeBuilder<Attachment> builder)
    {
        builder.HasKey(attachment => attachment.Id).HasName("attachmentId");
        builder.Property(attachment => attachment.FileName).HasMaxLength(250).IsRequired().HasColumnName("fileName");
        builder.Property(attachment => attachment.FilePath).IsRequired().HasColumnName("filePath");
        builder.Property(attachment => attachment.FileType).HasColumnName("fileType");
        
    }
}
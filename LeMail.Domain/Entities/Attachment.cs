using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Validators.Entities;

namespace LeMail.Domain.Entities;

public class Attachment : BaseEntity
{
    /// <summary>
    /// File name
    /// </summary>
    public string FileName { get; set; }
    /// <summary>
    /// File path
    /// </summary>
    public string FilePath { get; set; }
    
    /// <summary>
    /// Extensions of File
    /// </summary>
    public string FileType { get; set; }
    
    public Guid MessageId { get; set; }
    
    public Message Message { get; set; }

    public Attachment()
    {
        var validator = new AttachmentValidator(nameof(Attachment));
        validator.ValidateWithExceptions(this);
    }

    public void Update(string fileName, string filePath, string fileType)
    {
        FileName = fileName;
        FilePath = filePath;
        FileType = fileType;
        var validator = new AttachmentValidator(nameof(Attachment));
        validator.ValidateWithExceptions(this);
    }
}
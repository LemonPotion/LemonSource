using LeMail.Application.Dto_s.Message;

namespace LeMail.Application.Dto_s.Contact;

public class BaseContactDto
{
    public string ContactName { get; set; }
    public string ContactMail { get; set; }
    public string Description { get; set; }
    public Guid UserId { get; set; }
}
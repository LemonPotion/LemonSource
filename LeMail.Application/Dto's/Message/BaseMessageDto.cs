using LeMail.Application.Dto_s.User;

namespace LeMail.Application.Dto_s.Message;

public class BaseMessageDto
{
    public BaseUserDto User { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public DateTime DateSent { get; set; }
}
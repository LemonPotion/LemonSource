namespace LeMail.Application.Dto_s.Message.Requests;

public class DeleteMessageRequest: BaseMessageDto
{
    public Guid Id { get; init; }
}
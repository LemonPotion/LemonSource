using LeMail.Application.Dto_s.Message.Requests;
using LeMail.Application.Dto_s.Message.Responses;

namespace LeMail.Application.Interfaces.Services
{
    public interface IMessageService
    {
        //TODO: сделать получение всех сообщений от одного пользователя
        
        Task<CreateMessageResponse> CreateMessageAsync(CreateMessageRequest request, CancellationToken cancellationToken);
        Task<GetMessageResponse> GetMessageByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<UpdateMessageResponse> UpdateMessageAsync(UpdateMessageRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteMessageByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<GetMessageResponse>> GetAllMessagesAsync(CancellationToken cancellationToken);
    }
}
using LeMail.Domain.Entities;

namespace LeMail.Application.Interfaces.Repository;

public interface IMessageRepository : IBaseRepository<Message>
{
    Task<List<Message>> GetAllListByUserIdAsync(Guid id,CancellationToken cancellationToken);
}
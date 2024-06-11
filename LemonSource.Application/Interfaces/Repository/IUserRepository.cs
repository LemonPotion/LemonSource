using LeMail.Domain.Entities;

namespace LeMail.Application.Interfaces.Repository;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> LoginAsync(string email, string password, CancellationToken cancellationToken);
}
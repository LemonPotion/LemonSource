using LeMail.Application.Interfaces.Repository;
using LeMail.Application.Interfaces.Services;
using LeMail.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeMail.Persistence.Repositories;

//TODO: разобраться почему не добавляет в бд
public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _dbContext;

    public UserRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
    public async Task<User> CreateAsync(User entity, CancellationToken cancellationToken)
    {
        _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
    public async Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _dbContext.FindAsync<User>(new object[] { id }, cancellationToken);
        if (user is not null)
            return user;
        throw new ArgumentNullException(nameof(user));
    }

    public async Task<User> UpdateAsync(User entity, CancellationToken cancellationToken)
    {
        _dbContext.Update(entity); // Помечаем сущность как измененную
        await _dbContext.SaveChangesAsync(cancellationToken); // Сохраняем изменения в базе данных
        return entity;
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await GetByIdAsync(id,cancellationToken);
        _dbContext.Remove(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<List<User>> GetAllListAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Set<User>().ToListAsync(cancellationToken);
    }
}
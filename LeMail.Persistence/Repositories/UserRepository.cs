using FluentValidation;
using LeMail.Application.Interfaces.Repository;
using LeMail.Domain.Entities;
using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Validators.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeMail.Persistence.Repositories;
public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _dbContext;

    public UserRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
    public async Task<User> CreateAsync(User entity, CancellationToken cancellationToken)
    {
        var validator = new UserValidator(nameof(User));
        validator.ValidateWithExceptions(entity);
        
        _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
    public async Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _dbContext.FindAsync<User>( id , cancellationToken);
        if (user is not null)
            return user;
        throw new ArgumentNullException(nameof(user));
    }


    public async Task<User> UpdateAsync(User entity, CancellationToken cancellationToken)
    {
        entity.Update(entity.Email, entity.FullName);
        
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
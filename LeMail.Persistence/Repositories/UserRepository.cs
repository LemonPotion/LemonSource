using FluentValidation;
using LeMail.Application.Interfaces.Repository;
using LeMail.Domain.Entities;
using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Validators.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeMail.Persistence.Repositories;
/// <summary>
/// User repository
/// </summary>
public class UserRepository : IUserRepository
{
    /// <summary>
    /// Database context
    /// </summary>
    private readonly DatabaseContext _dbContext;

    public UserRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
    /// <summary>
    /// Create User
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<User> CreateAsync(User entity, CancellationToken cancellationToken)
    {
        
        var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == entity.Email, cancellationToken);
        if (existingUser is not null)
        {
            throw new Exception(string.Format(ExceptionMessages.UserAlreadyExists, entity.Email));
        }
        _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
    /// <summary>
    /// Get User by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _dbContext.FindAsync<User>( id , cancellationToken);
        return user;
    }
    /// <summary>
    /// Update User
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<User> UpdateAsync(User entity, CancellationToken cancellationToken)
    {
        entity.Update(entity.Email, entity.FullName);
        
        _dbContext.Update(entity); // Помечаем сущность как измененную
        await _dbContext.SaveChangesAsync(cancellationToken); // Сохраняем изменения в базе данных
        return entity;
    }
    /// <summary>
    /// Delete User by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await GetByIdAsync(id,cancellationToken);
        _dbContext.Remove(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
    /// <summary>
    /// Get all Users
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<User>> GetAllListAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Set<User>().ToListAsync(cancellationToken);
    }

    public async Task<User> LoginAsync(string email, string password, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email, cancellationToken);
        if (user is null) return null;
        
        return user.Password != password ? null : user;
    }
}
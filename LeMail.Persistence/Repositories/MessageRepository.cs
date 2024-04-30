using LeMail.Application.Interfaces.Repository;
using LeMail.Domain.Entities;
using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Validators.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeMail.Persistence.Repositories;
/// <summary>
/// Message repository
/// </summary>
public class MessageRepository : IMessageRepository
{
    /// <summary>
    /// Database context
    /// </summary>
    private readonly DatabaseContext _dbContext;

    public MessageRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    /// <summary>
    /// Create Message
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Message> CreateAsync(Message entity, CancellationToken cancellationToken)
    {
        _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    /// <summary>
    /// Get Message by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<Message> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var message = await _dbContext.FindAsync<Message>(id , cancellationToken);
        if (message is not null)
            return message;
        throw new ArgumentNullException(nameof(message));
    }
    /// <summary>
    /// Update Message 
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Message> UpdateAsync(Message entity, CancellationToken cancellationToken)
    {
        entity.Update(entity.Subject, entity.Body);
        _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
    /// <summary>
    /// Delete MEssage by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var message = await GetByIdAsync(id, cancellationToken);
        _dbContext.Remove(message);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
    /// <summary>
    /// Get all messages
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<Message>> GetAllListAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Message>().ToListAsync(cancellationToken);
    }
    /// <summary>
    /// Get all Messages by User id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<Message>> GetAllListByUserIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Messages
            .Where(c => c.UserId == id)
            .ToListAsync(cancellationToken);
    }
}
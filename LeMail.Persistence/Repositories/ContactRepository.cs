using LeMail.Application.Interfaces.Repository;
using LeMail.Domain.Entities;
using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Validators.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeMail.Persistence.Repositories;
/// <summary>
/// Contact repository
/// </summary>
public class ContactRepository : IContactRepository
{
    /// <summary>
    /// Database context
    /// </summary>
    private readonly DatabaseContext _dbContext;

    public ContactRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    /// <summary>
    /// Create Contact
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Contact> CreateAsync(Contact entity, CancellationToken cancellationToken)
    {
        _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    /// <summary>
    /// Get Contact by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<Contact> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var contact = await _dbContext.FindAsync<Contact>( id ,cancellationToken);
        if (contact is not null)
            return contact;
        throw new ArgumentNullException(nameof(contact));
    }
    /// <summary>
    /// Update Contact
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Contact> UpdateAsync(Contact entity, CancellationToken cancellationToken)
    {
        entity.Update(entity.ContactName, entity.ContactMail, entity.Description);
        
        _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
    /// <summary>
    /// Delete Contact by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var contact = await GetByIdAsync(id, cancellationToken);
        _dbContext.Remove(contact);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
    /// <summary>
    /// Get all contacts
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<Contact>> GetAllListAsync(CancellationToken cancellationToken)
    {
        return await _dbContext
            .Set<Contact>()
            .ToListAsync(cancellationToken);
    }
    /// <summary>
    /// Get list of Contacts by User id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<Contact>> GetAllListByUserIdAsync(Guid id,CancellationToken cancellationToken)
    {
        return await _dbContext.Contacts
            .Where(c => c.UserId == id)
            .ToListAsync(cancellationToken);
    }
}
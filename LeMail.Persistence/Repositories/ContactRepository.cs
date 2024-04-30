using LeMail.Application.Interfaces.Repository;
using LeMail.Domain.Entities;
using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Validators.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeMail.Persistence.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly DatabaseContext _dbContext;

    public ContactRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Contact> CreateAsync(Contact entity, CancellationToken cancellationToken)
    {
        var validator = new ContactValidator(nameof(Contact));
        validator.ValidateWithExceptions(entity);

        _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<Contact> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var contact = await _dbContext.FindAsync<Contact>( id ,cancellationToken);
        if (contact is not null)
            return contact;
        throw new ArgumentNullException(nameof(contact));
    }

    public async Task<Contact> UpdateAsync(Contact entity, CancellationToken cancellationToken)
    {
        entity.Update(entity.ContactName, entity.ContactMail, entity.Description);
        
        _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var contact = await GetByIdAsync(id, cancellationToken);
        _dbContext.Remove(contact);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<List<Contact>> GetAllListAsync(CancellationToken cancellationToken)
    {
        return await _dbContext
            .Set<Contact>()
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Contact>> GetAllListByUserIdAsync(Guid id,CancellationToken cancellationToken)
    {
        return await _dbContext.Contacts
            .Where(c => c.UserId == id)
            .ToListAsync(cancellationToken);
    }
}
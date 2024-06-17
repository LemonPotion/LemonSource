using LeMail.Application.Interfaces.Repository;
using LeMail.Domain.Entities;
using LeMail.Domain.Validations;
using Microsoft.EntityFrameworkCore;

namespace LeMail.Persistence.Repositories;

public abstract class RepositoryBase<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly DatabaseContext DbContext;

    protected RepositoryBase(DatabaseContext dbContext)
    {
        DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public virtual async Task<T> CreateAsync(T entity, CancellationToken cancellationToken)
    {
        DbContext.Add(entity);
        await DbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public virtual async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await DbContext.FindAsync<T>(id, cancellationToken);
        if (entity is not null)
            return entity;
        throw new ArgumentNullException(nameof(entity));
    }

    public virtual async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        DbContext.Update(entity);
        await DbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public virtual async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        DbContext.Remove(entity);
        await DbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public virtual async Task<List<T>> GetAllListAsync(CancellationToken cancellationToken)
    {
        return await DbContext.Set<T>().ToListAsync(cancellationToken);
    }
}
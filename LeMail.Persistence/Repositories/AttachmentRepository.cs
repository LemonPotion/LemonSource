using LeMail.Application.Interfaces.Repository;
using LeMail.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LeMail.Persistence.Repositories
{
    public class AttachmentRepository : IAttachmentRepository
    {
        private readonly DatabaseContext _dbContext;

        public AttachmentRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Attachment> CreateAsync(Attachment entity, CancellationToken cancellationToken)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<Attachment> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.FindAsync<Attachment>(id, cancellationToken);
            if (entity is not null)
                return entity;
            throw new ArgumentNullException(nameof(entity));
        }

        public async Task<Attachment> UpdateAsync(Attachment entity, CancellationToken cancellationToken)
        {
            entity.Update(entity.FileName, entity.FilePath, entity.FileType);
            
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            _dbContext.Remove(entity); 
            await _dbContext.SaveChangesAsync(cancellationToken); 
            return true;
        }

        public async Task<List<Attachment>> GetAllListAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Set<Attachment>().ToListAsync(cancellationToken);
        }
    }
}
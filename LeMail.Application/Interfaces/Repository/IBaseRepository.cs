using LeMail.Domain.Entities;

namespace LeMail.Application.Interfaces.Repository;

public interface IBaseRepository<TEntity> where TEntity: BaseEntity
{
    /// <summary>
    /// Create crud
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Новая сущность</returns>
    public Task<TEntity> CreateAsync(TEntity entity , CancellationToken cancellationToken);
    
    /// <summary>
    /// Read crud
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Сущность</returns>
    public Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Update crud
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Обновленную сущность</returns>
    public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    
    /// <summary>
    /// Delete crud
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>bool результат</returns>
    public Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получить лист 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List содержащий все сущности</returns>
    public Task<List<TEntity>> GetAllListAsync(CancellationToken cancellationToken);
    
}
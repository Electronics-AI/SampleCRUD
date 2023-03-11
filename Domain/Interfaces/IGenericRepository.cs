using Task5_CRUD.Domain;

namespace Task5_CRUD.Domain.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : Entity<int>
{
        Task<TEntity> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);
        
        Task UpdateAsync(TEntity updatedEntity);

        Task RemoveAsync(TEntity entity);
        
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);
}

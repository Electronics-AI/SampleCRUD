using Microsoft.EntityFrameworkCore;
using Task5_CRUD.Domain;
using Task5_CRUD.Domain.Interfaces;
using Task5_CRUD.Infrastructure.DbContexts;

namespace Task5_CRUD.Infrastructure.Repositories;

public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity<int>
{
    protected readonly CrudContext _context;

    public GenericRepository(CrudContext context)
    {
        _context = context ?? 
            throw new ArgumentNullException(nameof(context));
    }

    public async Task AddAsync(TEntity entity)
    {   
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task RemoveAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity newEntity)
    {
        _context.Set<TEntity>().Update(newEntity);
        await _context.SaveChangesAsync();
    }
}
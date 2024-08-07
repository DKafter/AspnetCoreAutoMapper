using dotnetautomapper.Data;
using dotnetautomapper.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dotnetautomapper.Repositories.Customer;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly BaseDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public BaseRepository(BaseDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<TEntity?> GetAsync(int? id)
    {
        var result = await _dbSet.FindAsync(id);
        return result;
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        await Task.Run(()=> _dbSet.Attach(entity));
        _context.Entry(entity).State = EntityState.Modified;
    }

    public async Task DeleteAsync(int id)
    {
        var dataToDelete = await _dbSet.FindAsync(id);
        _dbSet.Remove(dataToDelete);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
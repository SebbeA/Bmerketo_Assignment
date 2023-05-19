using Bmerketo.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bmerketo.Repositories;

public abstract class RepositoryDataContext<TEntity> where TEntity : class
{
    private readonly DataContext _context;

    protected RepositoryDataContext(DataContext context)
    {
        _context = context;
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        return entity!;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var entities = await _context.Set<TEntity>().ToListAsync();
        return entities;
    }
}

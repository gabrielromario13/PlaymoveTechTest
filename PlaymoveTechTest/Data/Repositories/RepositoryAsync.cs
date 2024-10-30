using Microsoft.EntityFrameworkCore;
using PlaymoveTechTest.Domain.Interfaces;
using PlaymoveTechTest.Domain.Model;
using System.Linq.Expressions;

namespace PlaymoveTechTest.Data.Repositories;

public class RepositoryAsync<T>
    : IRepositoryAsync<T> where T : BaseEntity
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public RepositoryAsync(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task Create(T entity)
    {
        await _dbSet.AddAsync(entity);

        await _context.SaveChangesAsync();
    }

    public async Task<T> GetById(int id) =>
        (await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id))!;

    public async Task<T> GetSingle(Expression<Func<T, bool>> predicate = default!)
    {
        var query = _dbSet.AsNoTracking();

        if (predicate is not null)
            query = query.Where(predicate);

        return (await query.FirstOrDefaultAsync())!;
    }

    public async Task<IEnumerable<T>> Get() =>
        await _dbSet.AsNoTracking().ToListAsync();

    public Task Update(T entity)
    {
        _dbSet.Update(entity);

        _context.SaveChanges();

        return Task.CompletedTask;
    }

    public async Task Delete(int id)
    {
        var result = await _dbSet.FirstOrDefaultAsync(c => c.Id == id);

        if (result is not null)
            _dbSet.Remove(result);

        await _context.SaveChangesAsync();
    }
}
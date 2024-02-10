using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class GenericRepository<TEntity>(Context _context) : IGenericRepository<TEntity> where TEntity : class
{
    public async Task<TEntity> GetById(int id)
        => await _context.Set<TEntity>().FindAsync(id) ?? throw new NullReferenceException();

    public async Task<List<TEntity>> Get()
        => await _context.Set<TEntity>().ToListAsync();

    public async Task<TEntity> Post(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}


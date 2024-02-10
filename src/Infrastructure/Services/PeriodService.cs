using Application.Common.Interfaces;
using Domain.Entidades;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class PeriodService(Context _context) : IPeriodService
{
    public async Task<Period> GetById(int id)
            => await _context.Period.FindAsync(id) ?? null!;

    public async Task<List<Period>> Get()
        => await _context.Period.ToListAsync();

    public async Task<Period> Post(Period entity)
    {
        await _context.Period.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Period> Update(Period entity)
    {
        _context.Period.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Period> Delete(Period entity)
    {
        _context.Period.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
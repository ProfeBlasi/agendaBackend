using Application.Common.Interfaces;
using Domain.Entidades;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

internal class ObservationsService(Context _context) : IObservationsService
{
    public async Task<Observations> GetById(int id)
            => await _context.Observations.FindAsync(id) ?? null!;

    public async Task<List<Observations>> Get()
        => await _context.Observations.ToListAsync();

    public async Task<Observations> Post(Observations entity)
    {
        await _context.Observations.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Observations> Update(Observations entity)
    {
        _context.Observations.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Observations> Delete(Observations entity)
    {
        _context.Observations.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
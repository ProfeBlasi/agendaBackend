using Application.Common.Interfaces;
using Domain.Entidades;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class HolidayService(Context _context) : IHolidayService
{
    public async Task<Holiday> GetById(int id)
        => await _context.Holiday.FindAsync(id) ?? null!;

    public async Task<List<Holiday>> Get()
        => await _context.Holiday.ToListAsync();

    public async Task<Holiday> Post(Holiday entity)
    {
        await _context.Holiday.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Holiday> Update(Holiday entity)
    {
        _context.Holiday.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Holiday> Delete(Holiday entity)
    {
        _context.Holiday.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}

using Application.Common.Interfaces;
using Domain.Entidades;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ReminderService(Context _context) : IReminderService
{
    public async Task<Reminder> GetById(int id)
            => await _context.Reminder.FindAsync(id) ?? null!;

    public async Task<List<Reminder>> Get()
        => await _context.Reminder.ToListAsync();

    public async Task<Reminder> Post(Reminder entity)
    {
        await _context.Reminder.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Reminder> Update(Reminder entity)
    {
        _context.Reminder.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Reminder> Delete(Reminder entity)
    {
        _context.Reminder.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}

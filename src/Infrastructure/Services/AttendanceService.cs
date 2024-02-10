using Application.Common.Interfaces;
using Domain.Entidades;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AttendanceService(Context _context) : IAttendanceService
{
    public async Task<Attendance> GetById(int id)
            => await _context.Attendance.FindAsync(id) ?? null!;

    public async Task<List<Attendance>> Get()
        => await _context.Attendance.ToListAsync();

    public async Task<Attendance> Post(Attendance entity)
    {
        await _context.Attendance.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Attendance> Update(Attendance entity)
    {
        _context.Attendance.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Attendance> Delete(Attendance entity)
    {
        _context.Attendance.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}

using Application.Common.Interfaces;
using Domain.Entidades;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class StudentPeriodService(Context _context) : IStudentPeriodService
{
    public async Task<StudentPeriod> GetById(int id)
            => await _context.StudentPeriod.FindAsync(id) ?? null!;

    public async Task<List<StudentPeriod>> Get()
        => await _context.StudentPeriod.ToListAsync();

    public async Task<StudentPeriod> Post(StudentPeriod entity)
    {
        await _context.StudentPeriod.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<StudentPeriod> Update(StudentPeriod entity)
    {
        _context.StudentPeriod.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<StudentPeriod> Delete(StudentPeriod entity)
    {
        _context.StudentPeriod.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}

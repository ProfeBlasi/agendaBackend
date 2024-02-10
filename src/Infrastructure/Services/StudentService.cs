using Application.Common.Interfaces;
using Domain.Entidades;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class StudentService(Context _context) : IStudentService
{
    public async Task<Student> GetById(int id)
            => await _context.Student.FindAsync(id) ?? null!;

    public async Task<List<Student>> Get()
        => await _context.Student.ToListAsync();

    public async Task<Student> Post(Student entity)
    {
        await _context.Student.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Student> Update(Student entity)
    {
        _context.Student.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Student> Delete(Student entity)
    {
        _context.Student.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}

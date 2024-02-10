using Application.Common.Interfaces;
using Domain.Entidades;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class StudentTestService(Context _context) : IStudentTestService
{
    public async Task<StudentTest> GetById(int id)
            => await _context.StudentTest.FindAsync(id) ?? null!;

    public async Task<List<StudentTest>> Get()
        => await _context.StudentTest.ToListAsync();

    public async Task<StudentTest> Post(StudentTest entity)
    {
        await _context.StudentTest.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<StudentTest> Update(StudentTest entity)
    {
        _context.StudentTest.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<StudentTest> Delete(StudentTest entity)
    {
        _context.StudentTest.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}


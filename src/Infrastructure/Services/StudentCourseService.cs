using Application.Common.Interfaces;
using Domain.Entidades;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class StudentCourseService(Context _context) : IStudentCourseService
{
    public async Task<StudentCourse> GetById(int id)
            => await _context.StudentCourse.FindAsync(id) ?? null!;

    public async Task<List<StudentCourse>> Get()
        => await _context.StudentCourse.ToListAsync();

    public async Task<StudentCourse> Post(StudentCourse entity)
    {
        await _context.StudentCourse.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<StudentCourse> Update(StudentCourse entity)
    {
        _context.StudentCourse.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<StudentCourse> Delete(StudentCourse entity)
    {
        _context.StudentCourse.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}

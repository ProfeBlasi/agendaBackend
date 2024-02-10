using Application.Common.Interfaces;
using Domain.Entidades;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CourseService(Context _context) : ICourseService
{
    public async Task<Course> GetById(int id)
            => await _context.Course.FindAsync(id) ?? null!;

    public async Task<List<Course>> Get()
        => await _context.Course.ToListAsync();

    public async Task<Course> Post(Course entity)
    {
        await _context.Course.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Course> Update(Course entity)
    {
        _context.Course.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Course> Delete(Course entity)
    {
        _context.Course.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}

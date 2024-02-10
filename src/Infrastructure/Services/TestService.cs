using Application.Common.Interfaces;
using Domain.Entidades;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class TestService(Context _context) : ITestService
{
    public async Task<Test> GetById(int id)
            => await _context.Test.FindAsync(id) ?? null!;

    public async Task<List<Test>> Get()
        => await _context.Test.ToListAsync();

    public async Task<Test> Post(Test entity)
    {
        await _context.Test.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Test> Update(Test entity)
    {
        _context.Test.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Test> Delete(Test entity)
    {
        _context.Test.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}


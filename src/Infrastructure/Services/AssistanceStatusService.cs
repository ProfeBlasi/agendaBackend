using Application.Common.Interfaces;
using Domain.Entidades;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AssistanceStatusService(Context _context) : IAssistanceStatusService
{
    public async Task<AssistanceStatus> GetById(int id)
            => await _context.AssistanceStatus.FindAsync(id) ?? null!;

    public async Task<List<AssistanceStatus>> Get()
        => await _context.AssistanceStatus.ToListAsync();

    public async Task<AssistanceStatus> Post(AssistanceStatus entity)
    {
        await _context.AssistanceStatus.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<AssistanceStatus> Update(AssistanceStatus entity)
    {
        _context.AssistanceStatus.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<AssistanceStatus> Delete(AssistanceStatus entity)
    {
        _context.AssistanceStatus.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
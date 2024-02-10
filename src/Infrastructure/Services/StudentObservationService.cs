using Application.Common.Interfaces;
using Domain.Entidades;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class StudentObservationService(Context _context) : IStudentObservationService
{ 
    public async Task<StudentObservation> GetById(int id)
            => await _context.StudentObservation.FindAsync(id) ?? null!;

    public async Task<List<StudentObservation>> Get()
        => await _context.StudentObservation.ToListAsync();

    public async Task<StudentObservation> Post(StudentObservation entity)
    {
        await _context.StudentObservation.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<StudentObservation> Update(StudentObservation entity)
    {
        _context.StudentObservation.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<StudentObservation> Delete(StudentObservation entity)
    {
        _context.StudentObservation.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
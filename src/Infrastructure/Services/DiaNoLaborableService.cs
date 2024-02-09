using Application.Common.Interfaces;
using Domain.Entidades;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class DiaNoLaborableService(Context _context) : IDiaNoLaborableService
    {
        public async Task<DiaNoLaborable> GetByIdDiaNoLaborable(int id)
            => await _context.DiaNoLaborable.FindAsync(id) ?? null!;

        public async Task<List<DiaNoLaborable>> GetDiaNoLaborable()
            => await _context.DiaNoLaborable.ToListAsync();

        public async Task<DiaNoLaborable> PostDiaNoLaborable(DiaNoLaborable diaNoLaborable)
        {
            await _context.DiaNoLaborable.AddAsync(diaNoLaborable);
            await _context.SaveChangesAsync();
            return diaNoLaborable;
        }

        public async Task<DiaNoLaborable> UpdateDiaNoLaborable(DiaNoLaborable diaNoLaborable)
        {
            _context.DiaNoLaborable.Update(diaNoLaborable);
            await _context.SaveChangesAsync();
            return diaNoLaborable;
        }

        public async Task<DiaNoLaborable> DeleteDiaNoLaborable(DiaNoLaborable diaNoLaborable)
        {
            _context.DiaNoLaborable.Remove(diaNoLaborable);
            await _context.SaveChangesAsync();
            return diaNoLaborable;
        }
    }
}

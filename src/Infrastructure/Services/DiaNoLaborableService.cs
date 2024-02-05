using Application.Common.Interfaces;
using Domain.Entidades;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class DiaNoLaborableService : IDiaNoLaborableService
    {
        private readonly Context _context;

        public DiaNoLaborableService(Context context)
        {
            _context = context;
        }

        public async Task<List<DiaNoLaborable>> GetDiaNoLaborable()
        {
            return await _context.DiaNoLaborable.ToListAsync();
        }
    }
}

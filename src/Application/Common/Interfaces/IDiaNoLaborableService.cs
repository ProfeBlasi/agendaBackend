using Domain.Entidades;

namespace Application.Common.Interfaces
{
    public interface IDiaNoLaborableService : IScopedService
    {
        Task<List<DiaNoLaborable>> GetDiaNoLaborable();
        Task<DiaNoLaborable> GetByIdDiaNoLaborable(int id);
        Task<DiaNoLaborable> PostDiaNoLaborable(DiaNoLaborable diaNoLaborable);
        Task<DiaNoLaborable> UpdateDiaNoLaborable(DiaNoLaborable diaNoLaborable);
        Task<DiaNoLaborable> DeleteDiaNoLaborable(DiaNoLaborable diaNoLaborable);
    }
}

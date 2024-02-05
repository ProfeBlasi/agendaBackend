using Domain.Entidades;

namespace Application.Common.Interfaces
{
    public interface IDiaNoLaborableService : IScopedService
    {
        Task<List<DiaNoLaborable>> GetDiaNoLaborable();
    }
}

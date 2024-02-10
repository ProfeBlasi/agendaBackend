using Domain.Entidades;

namespace Application.Common.Interfaces;

public interface IPeriodService : IScopedService
{
    Task<List<Period>> Get();
    Task<Period> GetById(int id);
    Task<Period> Post(Period entity);
    Task<Period> Update(Period entity);
    Task<Period> Delete(Period entity);
}


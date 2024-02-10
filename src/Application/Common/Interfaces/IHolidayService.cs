using Domain.Entidades;

namespace Application.Common.Interfaces;

public interface IHolidayService : IScopedService
{
    Task<List<Holiday>> Get();
    Task<Holiday> GetById(int id);
    Task<Holiday> Post(Holiday entity);
    Task<Holiday> Update(Holiday entity);
    Task<Holiday> Delete(Holiday entity);
}

using Domain.Entidades;

namespace Application.Common.Interfaces;

public interface IObservationsService : IScopedService
{
    Task<List<Observations>> Get();
    Task<Observations> GetById(int id);
    Task<Observations> Post(Observations entity);
    Task<Observations> Update(Observations entity);
    Task<Observations> Delete(Observations entity);
}



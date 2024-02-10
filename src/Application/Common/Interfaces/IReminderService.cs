using Domain.Entidades;

namespace Application.Common.Interfaces;

public interface IReminderService : IScopedService
{
    Task<List<Reminder>> Get();
    Task<Reminder> GetById(int id);
    Task<Reminder> Post(Reminder entity);
    Task<Reminder> Update(Reminder entity);
    Task<Reminder> Delete(Reminder entity);
}
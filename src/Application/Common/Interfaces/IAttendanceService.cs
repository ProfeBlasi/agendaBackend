using Domain.Entidades;

namespace Application.Common.Interfaces;

public interface IAttendanceService : IScopedService
{
    Task<List<Attendance>> Get();
    Task<Attendance> GetById(int id);
    Task<Attendance> Post(Attendance entity);
    Task<Attendance> Update(Attendance entity);
    Task<Attendance> Delete(Attendance entity);
}
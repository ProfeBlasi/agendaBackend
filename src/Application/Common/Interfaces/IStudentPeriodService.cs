using Domain.Entidades;

namespace Application.Common.Interfaces;

public interface IStudentPeriodService : IScopedService
{
    Task<List<StudentPeriod>> Get();
    Task<StudentPeriod> GetById(int id);
    Task<StudentPeriod> Post(StudentPeriod entity);
    Task<StudentPeriod> Update(StudentPeriod entity);
    Task<StudentPeriod> Delete(StudentPeriod entity);
}


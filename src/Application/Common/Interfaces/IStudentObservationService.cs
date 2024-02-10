using Domain.Entidades;

namespace Application.Common.Interfaces;

public interface IStudentObservationService : IScopedService
{
    Task<List<StudentObservation>> Get();
    Task<StudentObservation> GetById(int id);
    Task<StudentObservation> Post(StudentObservation entity);
    Task<StudentObservation> Update(StudentObservation entity);
    Task<StudentObservation> Delete(StudentObservation entity);
}


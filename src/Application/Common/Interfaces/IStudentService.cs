using Domain.Entidades;

namespace Application.Common.Interfaces;

public interface IStudentService : IScopedService
{
    Task<List<Student>> Get();
    Task<Student> GetById(int id);
    Task<Student> Post(Student entity);
    Task<Student> Update(Student entity);
    Task<Student> Delete(Student entity);
}

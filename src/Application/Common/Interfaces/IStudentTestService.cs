using Domain.Entidades;

namespace Application.Common.Interfaces;

public interface IStudentTestService : IScopedService
{
    Task<List<StudentTest>> Get();
    Task<StudentTest> GetById(int id);
    Task<StudentTest> Post(StudentTest entity);
    Task<StudentTest> Update(StudentTest entity);
    Task<StudentTest> Delete(StudentTest entity);
}


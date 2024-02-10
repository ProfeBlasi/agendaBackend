using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IStudentCourseService : IScopedService
{
    Task<List<StudentCourse>> Get();
    Task<StudentCourse> GetById(int id);
    Task<StudentCourse> Post(StudentCourse entity);
    Task<StudentCourse> Update(StudentCourse entity);
    Task<StudentCourse> Delete(StudentCourse entity);
}

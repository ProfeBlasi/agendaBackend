using Domain.Entidades;

namespace Application.Common.Interfaces;

public interface ICourseService : IScopedService
{
    Task<List<Course>> Get();
    Task<Course> GetById(int id);
    Task<Course> Post(Course entity);
    Task<Course> Update(Course entity);
    Task<Course> Delete(Course entity);
}


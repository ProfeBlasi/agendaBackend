using Domain.Entidades;

namespace Application.Common.Interfaces;

public interface ITestService : IScopedService
{
    Task<List<Test>> Get();
    Task<Test> GetById(int id);
    Task<Test> Post(Test entity);
    Task<Test> Update(Test entity);
    Task<Test> Delete(Test entity);
}

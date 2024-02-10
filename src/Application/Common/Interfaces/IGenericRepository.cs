namespace Application.Common.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetById(int id);
    Task<List<TEntity>> Get();
    Task<TEntity> Post(TEntity entity);
    Task<TEntity> Update(TEntity entity);
    Task<TEntity> Delete(TEntity entity);
}

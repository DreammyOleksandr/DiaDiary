using System.Linq.Expressions;

namespace DataAccess.IDataAccess;

public interface IMongoRepository<T>
{
    Task Create(T entity);
    Task<T> GetOne(Expression<Func<T, bool>> filter);
    IEnumerable<T> GetAll();
    Task Update(Expression<Func<T, bool>> filter, T entity);
    Task Delete(Expression<Func<T, bool>> filter);
    Task DeleteAll();
}
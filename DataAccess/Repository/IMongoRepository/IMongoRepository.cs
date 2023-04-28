using System.Linq.Expressions;

namespace DataAccess.IDataAccess;

public interface IMongoRepository<T>
{
    Task Create(T entity);
    IEnumerable<T> GetAll();
    Task FirstOrDefault(Expression<Func<T, bool>> filter, T entity);
    Task Delete(Expression<Func<T, bool>> filter);
    Task DeleteAll();
}
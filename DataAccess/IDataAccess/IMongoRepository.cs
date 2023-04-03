namespace DataAccess.IDataAccess;

public interface IMongoRepository<T>
{
      async Task Create(T item){}
      void GetAll(){}
      async Task Update(T item){}
      async Task Delete(){}
      async Task DeleteAll(){}

}
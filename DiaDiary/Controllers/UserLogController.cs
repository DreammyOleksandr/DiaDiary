using static System.Console;
using DataAccess;
using DataAccess.Models;
using Views;

namespace DiaDiary.Controllers;

public class UserLogController
{
    private readonly MongoRepository<UserLog> MongoRepository;

    public UserLogController(string databaseName, string userLogCollectionName)
    {
        MongoRepository = new MongoRepository<UserLog>(databaseName: databaseName, collectionName: userLogCollectionName);
    }


    public async Task Create()
    {
        UserLog userLog = new UserLog();
        UserLogView.Create(userLog);
        await MongoRepository.Create(userLog);
    }
    

    public void GetAll()
    {
        List<UserLog> UserLogs = MongoRepository.GetAll().ToList();
        UserLogView.ShowAll(UserLogs);
    }

    public void Update()
    {
        
    }

    public async Task DeleteAll()
    {
        await MongoRepository.DeleteAll();
    }
}
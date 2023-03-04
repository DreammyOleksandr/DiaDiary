using DataAccess;
using Models;

namespace DiaDiary;

class Program
{
    static void Main(string[] args)
    {

        MongoDbManager.DeleteByGlucoseLevel();
        Console.ReadKey();
    }
}
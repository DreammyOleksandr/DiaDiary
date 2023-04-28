using MongoDB.Driver;

namespace DiaDiary;

class Program
{
    static void Main()
    {
        string dbName = "diabeticslogs";
        MongoClient client = new MongoClient();
        IMongoDatabase db = client.GetDatabase(dbName);
    }
}
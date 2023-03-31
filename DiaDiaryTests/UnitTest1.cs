using DataAccess;
using Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DiaDiaryTests;

public class Tests
{

    private MongoClient _client;
    private IMongoDatabase _database;
    private IMongoCollection<BsonDocument> _collection;

    [SetUp]
    public void SetUp()
    {
        var connectionString = "mongodb://localhost:27017";

        _client = new MongoClient(connectionString);
        _database = _client.GetDatabase("diabeticslogs");
        _collection = _database.GetCollection<BsonDocument>("LogEntriesTest");
    }
    
    [TearDown]
    public void TearDown()
    {
        _database.DropCollection("LogEntriesTest");
    }
    
    
    [Test]
    public async Task InsertDocument_Success()
    {
        // Arrange
        var document = new BsonDocument
        {
            { "GlucoseLevel", 100 },
            { "ShortTermInsulin", 100 },
            { "LongTermInsulin", 100 },
            {"CarbsInBreadUnits", 100},
            {"Notes", "Unit test notes"}
        };
        
        await _collection.InsertOneAsync(document);
        
        var result = await _collection.Find(document).FirstOrDefaultAsync();
        Assert.IsNotNull(result);
    }
    
}


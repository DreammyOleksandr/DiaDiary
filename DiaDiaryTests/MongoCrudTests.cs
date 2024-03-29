using MongoDB.Bson;
using MongoDB.Driver;

namespace DiaDiaryTests;

public class MongoCrudTests
{
    private string DbName = "DiaDiary";
    private string CollectionName = "DiaDiary";

    private MongoClient _client;
    private IMongoDatabase _database;
    private IMongoCollection<BsonDocument> _collection;

    [SetUp]
    public void SetUp()
    {
        _client = new MongoClient();
        _database = _client.GetDatabase(DbName);
        _collection = _database.GetCollection<BsonDocument>(CollectionName);
    }

    [TearDown]
    public void TearDown()
    {
        _database.DropCollection(CollectionName);
    }


    [Test]
    public async Task InsertDocumentSuccess()
    {
        var document = new BsonDocument
        {
            { "GlucoseLevel", 100 },
            { "ShortTermInsulin", 100 },
            { "LongTermInsulin", 100 },
            { "CarbsInBreadUnits", 100 },
            { "Notes", "Unit test notes" }
        };

        await _collection.InsertOneAsync(document);

        var result = await _collection.Find(document).FirstOrDefaultAsync();
        Assert.IsNotNull(result);
    }

    [Test]
    public async Task UpdateDocumentSuccess()
    {
        var filter = Builders<BsonDocument>.Filter.Eq("GlucoseLevel", 100);
        var update = Builders<BsonDocument>.Update.Set("ShortTermInsulin", 40);

        await _collection.InsertOneAsync(new BsonDocument
        {
            { "GlucoseLevel", 100 },
            { "ShortTermInsulin", 100 },
            { "LongTermInsulin", 100 },
            { "CarbsInBreadUnits", 100 },
            { "Notes", "Unit test notes" }
        });

        UpdateResult? result = await _collection.UpdateOneAsync(filter, update);

        Assert.AreEqual(1, result.ModifiedCount);
    }

    [Test]
    public async Task DeleteDocumentSuccess()
    {
        var document = new BsonDocument
        {
            { "GlucoseLevel", 100 },
            { "ShortTermInsulin", 100 },
            { "LongTermInsulin", 100 },
            { "CarbsInBreadUnits", 100 },
            { "Notes", "Unit test notes" }
        };

        await _collection.InsertOneAsync(document);

        var result = await _collection.DeleteOneAsync(document);

        Assert.AreEqual(1, result.DeletedCount);
    }
}
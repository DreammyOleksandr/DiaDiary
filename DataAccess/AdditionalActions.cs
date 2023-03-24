using DataAccess;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DiaDiary;

public class AdditionalActions : ApplicationDbContext
{
    public static void GlycatedHemoglobin()
    {
        double glucoseSum = 0;
        long glucoseEntriesQuantity = collection.CountDocuments(_ => true);
        
        var filter = new BsonDocument();
        List<double> glucoseLeveList = collection.Distinct<double>("GlucoseLevel", filter).ToList();
        
        foreach (var glucoseLevel in glucoseLeveList)
        {
            glucoseSum += glucoseLevel;
        }

        var averageGlucoseLevel = glucoseSum / glucoseEntriesQuantity;
        Console.WriteLine(averageGlucoseLevel);
    }
}
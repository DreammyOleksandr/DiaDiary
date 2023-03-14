using DataAccess;
using Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DiaDiary;

public class AdditionalActions : ApplicationDbContext
{
    public static void GlycatedHemoglobin()
    {
        
        double avarageGlucoseLevel = 0;
        double glucoseSum = 0;
        long glucoseEntriesQuantity = collection.CountDocuments(_ => true);
        
        var filter = new BsonDocument();
        List<double> glucoseLeveList = collection.Distinct<double>("GlucoseLevel", filter).ToList();
        
        foreach (var glucoseLevel in glucoseLeveList)
        {
            glucoseSum += glucoseLevel;
        }

        avarageGlucoseLevel = glucoseSum / glucoseEntriesQuantity;
        Console.WriteLine(avarageGlucoseLevel);
    }
}
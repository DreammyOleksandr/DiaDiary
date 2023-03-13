using DataAccess;
using Models;
using MongoDB.Driver;

namespace DiaDiary;

public class AdditionalActions : ApplicationDbContext
{
    public static async Task AverageSugarLevel()
    {
        List<double> glucoseLeveList = collection.Distinct<double>("glucose level", "").ToList();
    }
}
using System.Collections;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models;

public class LogEntries : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        return new LogEntry();
    }
}

public class LogEntry
{
        
    [BsonId,BsonRepresentation(BsonType.ObjectId),Range(0, 50)]
    public string Id { get; set; }
    public double GlucoseLevel { get; set; }
    [Range(0, 50)] public double CarbsInBreadUnits { get; set; }
    public int ShortTermInsulin { get; set; }
    public int LongTermInsulin { get; set; }

    public DateTime Date { get; set; } = DateTime.Today;
    public DateTime Time { get; set; } = DateTime.Now;

    [Range(0, 250)] public string Notes { get; set; }
}
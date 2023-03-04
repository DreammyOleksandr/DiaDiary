using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models;

public class LogEntry
{
    private uint LogPosition = 1;
    
    [BsonId,BsonRepresentation(BsonType.ObjectId),Range(0, 50)]
    public string Id { get; set; }
    public int GlucoseLevel { get; set; }
    [Range(0, 50)] public int CarbohydratesInBreadUnits { get; set; }
    public int ShortTermInsulin { get; set; }
    public int LongTermInsulin { get; set; }

    public DateTime Date { get; set; } = DateTime.Today;
    public DateTime Time { get; set; } = DateTime.Now;

    [Range(0, 250)] public string Notes { get; set; }
}
using System.Collections;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models;

public class LogEntry
{
    public uint Order { get; set; } = 0;
    
    [BsonId, BsonRepresentation(BsonType.ObjectId), Range(0, 50)]
    public string? Id { get; set; }

    public double? GlucoseLevel { get; set; }
    [Range(0, 50)] public double? CarbsInBreadUnits { get; set; }
    public byte? ShortTermInsulin { get; set; }
    public byte? LongTermInsulin { get; set; }

    public DateTime Date { get; set; } = DateTime.Today;
    public DateTime Time { get; set; } = DateTime.Now;

    [Range(0, 250)] public string? Notes { get; set; } 
}

using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models;

public class LogEntry
{
    [BsonId, BsonRepresentation(BsonType.ObjectId), Range(0, 50)]
    public string? Id { get; set; }

    [DisplayName("Glucose level")]public double? GlucoseLevel { get; set; }
    [Range(0, 50), DisplayName("Carbs")] public double? CarbsInBreadUnits { get; set; }
    
    [DisplayName("S-term insulin injected")]
    public byte? ShortTermInsulin { get; set; }
    
    [DisplayName("L-term insulin injected")]
    public byte? LongTermInsulin { get; set; }

    public DateTime Date { get; set; } = DateTime.Today;
    public DateTime Time { get; set; } = DateTime.Now;

    [Range(0, 250)] public string? Notes { get; set; } 
}

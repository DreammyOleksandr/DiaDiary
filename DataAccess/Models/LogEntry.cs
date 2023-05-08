using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Models;

public class LogEntry
{
    [BsonId, BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public double GlucoseLevel { get; set; }
    [Range(0, 50)] public double CarbsInBreadUnits { get; set; }
    
    [DisplayName("Stop")]
    public byte ShortTermInsulin { get; set; }
    public byte LongTermInsulin { get; set; }

    public string MeasurementPeriod { get; set; }

    public DateTime Date { get; set; } = DateTime.Today;
    public DateTime Time { get; set; } = DateTime.Now;

    [Range(0, 250)] public string? Notes { get; set; } 
}

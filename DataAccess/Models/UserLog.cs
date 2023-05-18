using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Models;

public class UserLog
{
    [BsonId, BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public double GlucoseLevel { get; set; }
    [Range(0, 50)] public double CarbsInBreadUnits { get; set; }
    
    public byte ShortTermInsulin { get; set; }
    public byte LongTermInsulin { get; set; }
    
    public DateTime Date { get; set; } = DateTime.Today;
    public DateTime Time { get; set; } = DateTime.Now;

    [Range(0, 250)] public string? Notes { get; set; } 
    
    public ApplicationUser AssignedTo { get; set; }
}

using System.Collections;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models;

public class LogEntry
{
    [BsonId,BsonRepresentation(BsonType.ObjectId),Range(0, 50)]
    public string Id { get; set; } = null;

    public double? GlucoseLevel { get; set; } = 0;
    [Range(0, 50)] public double? CarbsInBreadUnits { get; set; } = 0;
    public byte? ShortTermInsulin { get; set; } = 0;
    public byte? LongTermInsulin { get; set; } = 0;

    public DateTime Date { get; set; } = DateTime.Today;
    public DateTime Time { get; set; } = DateTime.Now;

    [Range(0, 250)] public string Notes { get; set; } = null;
}

// public class LogEntries : IEnumerable
// {
//     private LogEntry[] _logEntries;
//     public LogEntries(LogEntry[] logEntryArray)
//     {
//         _logEntries = new LogEntry[logEntryArray.Length];
//
//         for (int i = 0; i < logEntryArray.Length; i++)
//         {
//             _logEntries = new[] { logEntryArray[i] };
//         }
//     }
//     public IEnumerator GetEnumerator()
//     {
//         return (IEnumerator) GetEnumerator();
//     }
//
//     public PeopleEnum GetEnumerator()
//     {
//         return new PeopleEnum(_logEntries);
//     }
// }
//
// public class PeopleEnum : IEnumerator
// {
//     public object Current { get; }
//     
//     public bool MoveNext()
//     {
//         throw new NotImplementedException();
//     }
//
//     public void Reset()
//     {
//         throw new NotImplementedException();
//     }
// }
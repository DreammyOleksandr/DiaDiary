using System.ComponentModel.DataAnnotations;

namespace Models;

public class LogEntry
{
    [Range(0, 50)] public int GlucoseLevel { get; set; }
    [Range(0, 50)] public int CarbohydratesInBreadUnits { get; set; }
    public int ShortTermInsulin { get; set; }
    public int LongTermInsulin { get; set; }

    public DateTime Date { get; set; } = DateTime.Today;
    public DateTime Time { get; set; } = DateTime.Now;

    [Range(0, 250)] public string Notes { get; set; }
}
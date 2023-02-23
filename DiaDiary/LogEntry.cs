using System.ComponentModel.DataAnnotations;

namespace DiaDiary;

public class LogEntry
{
    [Range(0, 50)] public int GlucoseLevel { get; set; }
    [Range(0, 50)] public int CarbohydratesInBreadUnits { get; set; }
    public int ShortTermInsulin { get; set; }
    public int LongTermInsulin { get; set; }

    public DateTime Date { get; set; } = DateTime.Today;

    public DateTime time = DateTime.Now;

    public DateTime Time
    {
        get { return time; }
        set
        {
            value = Convert.ToDateTime(time.ToString("t"));
        }
    }

    [Range(0, 250)] public string Notes { get; set; }
}
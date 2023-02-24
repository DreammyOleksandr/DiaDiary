using DataAccess;

namespace DiaDiary;

class Program
{
    static void Main(string[] args)
    {
        var userData = new LogEntry();
        Console.WriteLine(userData.Time.ToString("t") + "\t" + userData.Date.ToString("yyyy MMMM dd"));
    }
}
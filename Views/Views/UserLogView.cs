using static System.Console;
using DataAccess.Models;

namespace Views;

public class UserLogView
{
    public static void ShowAll(IEnumerable<UserLog> userLogs)
    {
        foreach (var userLog in userLogs)
        {
            WriteLine($"Glucose level: {userLog.GlucoseLevel}\n" +
                      $"Short term insulin injected: {userLog.ShortTermInsulin}\n" +
                      $"Long term insulin injected: {userLog.LongTermInsulin}\n" +
                      $"Carbs eaten: {userLog.CarbsInBreadUnits}\n" +
                      $"Notes: {userLog.Notes}\n");
        }
    }
    public static UserLog Create(UserLog userLog)
    {
        Write($"Glucose level: ");
        userLog.GlucoseLevel = double.Parse(ReadLine());
        Write($"S-term insulin: ");
        userLog.ShortTermInsulin = byte.Parse(ReadLine());
        Write($"L-term insulin: ");
        userLog.LongTermInsulin = byte.Parse(ReadLine());
        Write($"Carbs eaten: ");
        userLog.CarbsInBreadUnits = double.Parse(ReadLine());
        Write($"Notes: ");
        userLog.Notes = ReadLine();

        return userLog;
    }
}
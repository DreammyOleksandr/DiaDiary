using static System.Console;
using DataAccess.Models;

namespace View.Views;

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
}
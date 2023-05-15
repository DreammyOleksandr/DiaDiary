using static System.Console;
using DataAccess.Models;

namespace Views;

public class UserLogView
{
    public static void ShowAll(IEnumerable<UserLog> userLogs)
    {
        Clear();
        foreach (var userLog in userLogs)
        {
            WriteLine($"Id: {userLog.Id}\n" +
                      $"Glucose level: {userLog.GlucoseLevel}\n" +
                      $"Short term insulin injected: {userLog.ShortTermInsulin}\n" +
                      $"Long term insulin injected: {userLog.LongTermInsulin}\n" +
                      $"Carbs eaten: {userLog.CarbsInBreadUnits}\n" +
                      $"Notes: {userLog.Notes}\n");
        }
    }
    public static UserLog Create(UserLog userLog)
    {
        Clear();
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
        
        Write("\nPress any key to continue");
        ReadKey();
        
        return userLog;
    }

    public static UserLog Update(string? userLogId)
    {
        Clear();
        UserLog UpdatedLog = new UserLog();
        UpdatedLog.Id = userLogId;
        
        WriteLine("Enter Id of the log that you want to update: ");
        
        Write($"Glucose level: ");
        UpdatedLog.GlucoseLevel = double.Parse(ReadLine());
        Write($"S-term insulin: ");
        UpdatedLog.ShortTermInsulin = byte.Parse(ReadLine());
        Write($"L-term insulin: ");
        UpdatedLog.LongTermInsulin = byte.Parse(ReadLine());
        Write($"Carbs eaten: ");
        UpdatedLog.CarbsInBreadUnits = double.Parse(ReadLine());
        Write($"Notes: ");
        UpdatedLog.Notes = ReadLine();

        return UpdatedLog;
    }

    public static string Delete()
    {
        Clear();
        WriteLine("Enter Id of the log you want to delete: ");
        string IdToDelete = ReadLine();
        return IdToDelete;
    }
}
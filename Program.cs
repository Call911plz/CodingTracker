namespace CodingTracker;
using Spectre.Console;

class Program
{
    static void Main(string[] args)
    {
        SessionDBModel.CreateDB(); // REQUIRED TO MAKE DB
        
        var dataSet = SessionDBModel.SelectLog();

        Grid grid = new();

        grid.AddColumns(4);
        grid.AddRow(["Id", "Start Time", "End Time", "Duration"]);
        foreach (SessionData data in dataSet)
        {
            grid.AddRow([data.Id.ToString(), data.StartTime, data.EndTime, data.Duration.ToString()]);
        }

        AnsiConsole.Write(grid);

        SessionDBModel.ExitDB(); // REQUIRED TO CLOSE DB
    }
}

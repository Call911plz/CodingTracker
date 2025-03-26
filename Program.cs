namespace CodingTracker;
using Spectre.Console;

class Program
{
    static void Main(string[] args)
    {
        SessionDBModel.CreateDB(); // REQUIRED TO MAKE DB

        var dataSet = SessionDBModel.SelectLog();
        UserInterface.DisplaySessionData(dataSet);

        SessionDBModel.ExitDB(); // REQUIRED TO CLOSE DB
    }
}

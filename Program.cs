namespace CodingTracker;
using Spectre.Console;

class Program
{
    static void Main(string[] args)
    {
        // MainController.Start();

        SessionDBModel.CreateDB();
        Console.Clear();
        UserInterface.DisplaySessionData(SessionDBModel.SelectLog());
        SessionDBModel.ExitDB();
    }
}

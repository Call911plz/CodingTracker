namespace CodingTracker;
using Spectre.Console;

class Program
{
    static void Main(string[] args)
    {
        // Run main
        MainController.Start();

        // // Testing specific methods
        // SessionDBModel.CreateDB();
        // Console.Clear();
        // UserInterface.GetId([0,2,3,4,6,12]);
        // SessionDBModel.ExitDB();
    }
}

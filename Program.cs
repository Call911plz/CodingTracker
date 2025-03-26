namespace CodingTracker;

class Program
{
    static void Main(string[] args)
    {
        //UserInterface.StartUI();
        SessionDBModel.CreateDB(); // REQUIRED TO MAKE DB
        //SessionDBModel.CreateLog();
        SessionDBModel.SelectLog();
        SessionDBModel.ExitDB(); // REQUIRED TO CLOSE DB
    }
}

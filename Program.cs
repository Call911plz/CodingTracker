namespace CodingTracker;

class Program
{
    static void Main(string[] args)
    {
        //UserInterface.StartUI();
        SessionDBModel.CreateDB(); // REQUIRED TO MAKE DB
        SessionDBModel.SelectLog();
        SessionDBModel.UpdateLog(1, new SessionData() {
            StartTime = "FUCKING",
            EndTime = "GARBAGE",
            Duration = 69
        });
        SessionDBModel.SelectLog();
        SessionDBModel.ExitDB(); // REQUIRED TO CLOSE DB
    }
}

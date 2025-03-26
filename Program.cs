namespace CodingTracker;

class Program
{
    static void Main(string[] args)
    {
        SessionDBModel.CreateDB(); // REQUIRED TO MAKE DB
        SessionDBModel.SelectLog();
        SessionDBModel.DeleteLog(1);
        SessionDBModel.SelectLog();
        SessionDBModel.ExitDB(); // REQUIRED TO CLOSE DB
    }
}

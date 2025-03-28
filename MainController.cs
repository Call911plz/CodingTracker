

using Spectre.Console;

class MainController
{
    public static void Start()
    {
        bool shouldRun = true;
        SessionDBModel.CreateDB(); // REQUIRED TO MAKE DB

        while (shouldRun)
        {
            var startInput = UserInterface.GetStartUIInput(); // Get start menu input
            var dataSet = SessionDBModel.GetAllLog(); // Contains all current logs
            var avaliableIds = SessionDBModel.GetIdFromDB(); // Contains all current ids
            switch (startInput)
            {
                case Enums.MenuOption.CREATE:
                    Create();
                    break;
                
                case Enums.MenuOption.FINDALL:
                    FindAll(dataSet);
                    break;
                
                case Enums.MenuOption.UPDATE:
                    Update(dataSet, avaliableIds);
                    break;
                
                case Enums.MenuOption.DELETE:
                    Delete(dataSet, avaliableIds);
                    break;
                
                case Enums.MenuOption.EXIT:
                    shouldRun = false;
                    break;
            }
            if (shouldRun)
            {
                AnsiConsole.MarkupLine("Press [bold green]Enter[/] to return to continue");
                Console.Read();
            }
            
            SessionDBModel.ExitDB(); // REQUIRED TO CLOSE DB
        }
    }

    static void Create()
    {
        var dataCreate = UserInterface.GetSessionData(); // Get log from user
        SessionDBModel.InsertLog(dataCreate); // Insert Log
    }

    static void FindAll(List<SessionData> dataSet)
    {
        UserInterface.DisplaySessionData(dataSet); // Show all logs
    }

    static void Update(List<SessionData> dataSet, int[] allIds)
    {
        UserInterface.DisplaySessionData(dataSet); // Show all logs
        var id = UserInterface.GetId(allIds); // Get Id from user
        var data = UserInterface.GetSessionData(); // Get new log from user
        SessionDBModel.UpdateLog(id, data); // Update log
    }

    static void Delete(List<SessionData> dataSet, int[] allIds)
    {
        UserInterface.DisplaySessionData(dataSet); // Show all logs
        var idDelete = UserInterface.GetId(allIds); // Get Id from user
        SessionDBModel.DeleteLog(idDelete);
    }
}

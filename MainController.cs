

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
                    var dataCreate = UserInterface.GetSessionData(); // Get log from user
                    SessionDBModel.InsertLog(dataCreate); // Insert Log
                    break;
                
                case Enums.MenuOption.FINDALL:
                    UserInterface.DisplaySessionData(dataSet); // Show all logs
                    break;
                
                case Enums.MenuOption.UPDATE:
                    UserInterface.DisplaySessionData(dataSet); // Show all logs
                    var idUpdate = UserInterface.GetId(avaliableIds); // Get Id from user
                    var dataUpdate = UserInterface.GetSessionData(); // Get new log from user
                    SessionDBModel.UpdateLog(idUpdate, dataUpdate); // Update log
                    break;
                
                case Enums.MenuOption.DELETE:
                    UserInterface.DisplaySessionData(dataSet); // Show all logs
                    var idDelete = UserInterface.GetId(avaliableIds); // Get Id from user
                    SessionDBModel.DeleteLog(idDelete);
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
}

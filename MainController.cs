

using Spectre.Console;

class MainController
{
    public static void Start()
    {
        bool shouldRun = true;
        SessionDBModel.CreateDB(); // REQUIRED TO MAKE DB

        while (shouldRun)
        {
            var startInput = UserInterface.GetStartUIInput();
            var dataSet = SessionDBModel.SelectLog();
            switch (startInput)
            {
                case Enums.MenuOption.CREATE:
                    var data = UserInterface.GetSessionData();
                    SessionDBModel.InsertLog(data);
                    break;
                
                case Enums.MenuOption.FIND:
                    break;
                
                case Enums.MenuOption.FINDALL:
                    UserInterface.DisplaySessionData(dataSet);
                    break;
                
                case Enums.MenuOption.UPDATE:
                    UserInterface.DisplaySessionData(dataSet);
                    
                    break;
                
                case Enums.MenuOption.DELETE:
                    break;
                
                case Enums.MenuOption.EXIT:
                    shouldRun = false;
                    break;
            }
            if (shouldRun)
            {
                AnsiConsole.WriteLine("Press [bold green]Enter[/] to return to continue");
                Console.Read();
            }
            
            SessionDBModel.ExitDB(); // REQUIRED TO CLOSE DB
        }
    }
}

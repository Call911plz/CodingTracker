

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
            var dataSet = SessionDBModel.GetAllLog("Id"); // Contains all current logs
            var avaliableIds = SessionDBModel.GetIdFromDB(); // Contains all current ids
            switch (startInput)
            {
                case Enums.MenuOption.RECORD:
                    Record();
                    break;
                    
                case Enums.MenuOption.CREATE:
                    Create();
                    break;
                
                case Enums.MenuOption.FINDALL:
                    FindAll();
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

    private static void Record()
    {
        var data = UserInterface.GetRecordSession();
        SessionDBModel.InsertLog(data);
    }

    static void Create()
    {
        var data = UserInterface.GetSessionData(); // Get log from user
        SessionDBModel.InsertLog(data); // Insert Log
    }

    static void FindAll()
    {
        string userInput = "Id";
        bool desc = false;
        do
        {
            Console.Clear();
            var dataSet = SessionDBModel.GetAllLog(userInput, desc);
            UserInterface.DisplaySessionData(dataSet); // Show all logs

            // Change sort order
            userInput = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold green3_1]Sort by: [/]")
                .MoreChoicesText("[grey](Move up and down to reveal move options)[/]")
                .AddChoices([
                    "Id", "StartTime", "EndTime", "Duration", "Exit"
                ]));
            
            if (userInput != "Exit")
                desc = AnsiConsole.Prompt(
                    new TextPrompt<bool>("")
                        .AddChoice(true)
                        .AddChoice(false)
                        .DefaultValue(false)
                        .WithConverter(choice => choice ? "Desc" : "Asce"));

        }while(userInput != "Exit");
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

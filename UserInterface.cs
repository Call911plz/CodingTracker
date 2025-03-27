using Spectre.Console;

class UserInterface
{
    const string Create = "Start new session";
    const string FindAll = "View all sessions";
    const string Find = "Search logs";
    const string Update = "Update log";
    const string Delete = "Delete log";
    const string Exit = "Exit";

    public static Enums.MenuOption GetStartUIInput()
    {
        // Displays prompts for selection
        Console.Clear();
        var menuInput = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[green]Select Option: [/]")
                .MoreChoicesText("[grey](Move up and down to reveal move options)[/]")
                .AddChoices([
                    Create, FindAll, Find,
                    Update, Delete, Exit
                ]));
        
        // matchs input for enum
        switch (menuInput)
        {
            case Create:
                return Enums.MenuOption.CREATE;
            case FindAll:
                return Enums.MenuOption.FINDALL;
            case Find:
                return Enums.MenuOption.FIND;
            case Update:
                return Enums.MenuOption.UPDATE;
            case Delete:
                return Enums.MenuOption.DELETE;
            case Exit:
                return Enums.MenuOption.EXIT;
            default:
                return default;
        }
    }

    public static void DisplaySessionData(List<SessionData> dataSet)
    {
        Grid grid = new();

        grid.AddColumns(4);
        grid.AddRow(["Id", "Start Time", "End Time", "Duration"]);
        foreach (SessionData data in dataSet)
        {
            grid.AddRow([data.Id.ToString(), data.StartTime, data.EndTime, data.Duration.ToString()]);
        }

        AnsiConsole.Write(grid);
    }
}

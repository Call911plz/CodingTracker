using Spectre.Console;

class UserInterface
{
    const string Create = "Start new session";
    const string FindAll = "View all sessions";
    const string Find = "Search logs";
    const string Update = "Update log";
    const string Delete = "Delete log";
    const string Exit = "Exit";

    public static Enums.MenuOption StartUI()
    {
        Console.Clear();
        var menuInput = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[green]Select Option: [/]")
                .MoreChoicesText("[grey](Move up and down to reveal move options)[/]")
                .AddChoices([
                    Create, FindAll, Find,
                    Update, Delete, Exit
                ]));
        
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
}

using Spectre.Console;

class UserInterface
{
    static Style defaultTextStyle = new (foreground: Color.White);
    static Style defaultHeaderStyle = new (foreground: Color.White);
    const string Create = "[white]Start new session[/]";
    const string FindAll = "[white]View all sessions[/]";
    const string Find = "[white]Search session[/]";
    const string Update = "[white]Update session[/]";
    const string Delete = "[white]Delete session[/]";
    const string Exit = "[red]Exit[/]";

    public static Enums.MenuOption GetStartUIInput()
    {
        // Displays prompts for selection
        Console.Clear();
        AnsiConsole.Write(
            new FigletText("Coding Sessions Tracker")
                .Centered()
                .Color(Color.Green));

        var menuInput = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold green3_1]Select Option: [/]")
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
        Table table = new();
        
        table.BorderColor(Color.White);

        table.AddColumns(["Id", "Start Time", "End Time", "Duration"]);
        foreach (SessionData data in dataSet)
        {            
            Markup id = ToDefaultText(data.Id.ToString());
            Markup startTime = ToDefaultText(data.StartTime);
            Markup endTime = ToDefaultText(data.EndTime);
            Markup Duration = ToDefaultText(data.Duration.ToString());

            table.AddRow([id, startTime, endTime, Duration]);
        }

        AnsiConsole.Write(table);
    }

    public static SessionData GetSessionData()
    {
        SessionData sessionData = new();

        AnsiConsole.Markup("[bold]Enter Session Data [green](Press Enter for default)[/][/]\n\n");
        AnsiConsole.Markup("Enter starting time: \n");
        sessionData.StartTime = GetTime().ToString();
        AnsiConsole.Markup("\nEnter ending time: \n");
        sessionData.EndTime = GetTime().ToString();

        return sessionData;
    }

    public static DateTime GetTime()
    {
        DateTime date = default;
        DateTime time = default;

        string dateString = AnsiConsole.Prompt(
            new TextPrompt<string>("Start Date")
                .DefaultValue(DateTime.Now.ToString("d")) // Setting default value to todays date
                .Validate((s) => DateTime.TryParse(s, out _) // Lambda for parsing a valid date
                    ? ValidationResult.Success() : ValidationResult.Error("Invalid Format"))
            );
        DateTime.TryParse(dateString, out date);
        
        string timeString = AnsiConsole.Prompt(
            new TextPrompt<string>("Start Time")
                .DefaultValue(DateTime.Now.ToString("t")) // Setting default value to todays date
                .Validate((s) => DateTime.TryParse(s, out _) // Lambda for parsing a valid date
                    ? ValidationResult.Success() : ValidationResult.Error("Invalid Format"))
            );
        DateTime.TryParse(timeString, out time);
        
        return date.Add(time.TimeOfDay);
    }


    public static TimeOnly CalculateDuration(DateTime startTime, DateTime endTime)
    {
        return default;
    }

    static Markup ToDefaultText(string text)
    {
        return new Markup(text, defaultTextStyle);
    }
    static Markup ToDefaultHeader(string text)
    {
        return new Markup(text, defaultHeaderStyle);
    }
}

using Spectre.Console;

class UserInterface
{
    static Style defaultTextStyle = new (foreground: Color.White);
    static Style defaultHeaderStyle = new (foreground: Color.White);
    const string Record = "[white]Record new session[/]";
    const string Create = "[white]Enter new session[/]";
    const string FindAll = "[white]View all sessions[/]";
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
                    Record, Create, FindAll, Update, Delete, Exit
                ]));
        
        // matchs input for enum
        switch (menuInput)
        {
            case Record:
                return Enums.MenuOption.RECORD;
            case Create:
                return Enums.MenuOption.CREATE;
            case FindAll:
                return Enums.MenuOption.FINDALL;
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

    public static string GetSearchOrder()
    {
        string userInput = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold green3_1]Sort by: [/]")
                .MoreChoicesText("[grey](Move up and down to reveal move options)[/]")
                .AddChoices([
                    "Id", "StartTime", "EndTime", "Duration", "Exit"
                ]));
        
        return userInput;
    }

    public static bool GetDescending()
    {
        var desc = AnsiConsole.Prompt(
            new TextPrompt<bool>("")
                .AddChoice(true)
                .AddChoice(false)
                .DefaultValue(false)
                .WithConverter(choice => choice ? "Desc" : "Asce"));
        
        return desc;
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

        // Getting start time
        AnsiConsole.Markup("Enter starting time: \n");
        var startDate = GetDateTime("Start Date", "d");
        var startTime = GetDateTime("Start Time", "t").TimeOfDay;
        sessionData.StartTime = startDate.Add(startTime).ToString();

        // Getting end time
        AnsiConsole.Markup("\nEnter ending time: \n");
        var endDate = GetDateTime("End Date", "d");
        var endTime = GetDateTime("End Time", "t").TimeOfDay;
        sessionData.EndTime = endDate.Add(endTime).ToString();

        // Gettign duration
        sessionData.Duration = CalculateDuration(
            sessionData.StartDateTime(), sessionData.EndDateTime()
        ).ToString();

        return sessionData;
    }

    public static DateTime GetDateTime(string prompt, string format)
    {
        DateTime dateTime = default;

        string dateString = AnsiConsole.Prompt(
            new TextPrompt<string>(prompt)
                .DefaultValue(DateTime.Now.ToString(format)) // Setting default value to todays date
                .Validate((s) => DateTime.TryParse(s, out _) // Lambda for parsing a valid date
                    ? ValidationResult.Success() : ValidationResult.Error("Invalid Format"))
            );
        DateTime.TryParse(dateString, out dateTime);
        
        return dateTime;
    }

    public static SessionData GetRecordSession()
    {
        SessionData data = new();
        data.StartTime = DateTime.Now.ToString();
        
        // Just to wait for the user to press enter
        _ = AnsiConsole.Prompt(
            new TextPrompt<bool>("Press Enter to stop recording")
                .AddChoice(true)
                .DefaultValue(true)
                .WithConverter(choice => choice ? "Stop" : ""));

        data.EndTime = DateTime.Now.ToString();

        data.Duration = CalculateDuration(
            data.StartDateTime(), data.EndDateTime()
        ).ToString();

        return data;
    }

    public static int GetId(int[] allIds)
    {
        int userId = AnsiConsole.Prompt(
            new TextPrompt<int>("Select log from ID")
                .AddChoices(allIds)
        );
        return userId;
    }

    static TimeSpan CalculateDuration(DateTime startTime, DateTime endTime)
    {
        return endTime - startTime;
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

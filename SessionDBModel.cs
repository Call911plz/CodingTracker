using Dapper;
using Microsoft.Data.Sqlite;
using Spectre.Console;
class SessionDBModel
{
    static SqliteConnection connection = null;
    public static void CreateDB()
    {
        // using Dapper;
        var connectionString = $@"Data Source=CodingSessionTracker.db;";
        // Connect to the database
        connection = new SqliteConnection(connectionString);
        
        var sql = 
        $@"CREATE TABLE IF NOT EXISTS coding_sessions (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            StartTime TEXT,
            EndTime TEXT,
            Duration INTEGER)";
        
        connection.Execute(sql);
        
    }

    public static void InsertLog(SessionData data)
    {
        var sql = 
        $@"INSERT INTO coding_sessions (StartTime, EndTime, Duration)
            VALUES ('{data.StartTime}', '{data.EndTime}', {data.Duration})";
        connection.Execute(sql);
    }

    public static void SelectLog()
    {
        var sql = 
        $@"SELECT * FROM coding_sessions";
        List<SessionData> dataSet = connection.Query<SessionData>(sql).ToList();
        Grid grid = new();

        grid.AddColumns(4);
        grid.AddRow(["Id", "Start Time", "End Time", "Duration"]);
        foreach (SessionData data in dataSet)
        {
            grid.AddRow([data.Id.ToString(), data.StartTime, data.EndTime, data.Duration.ToString()]);
        }

        AnsiConsole.Write(grid);
    }

    public static void ExitDB()
    {
        connection.Close();
    }
}
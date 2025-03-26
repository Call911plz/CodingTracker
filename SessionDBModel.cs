using Dapper;
using Microsoft.Data.Sqlite;
class SessionDBModel
{
    static SqliteConnection connection = null;
    public static void CreateDB()
    {
        // using Dapper;
        var connectionString = "Data Source=CodingSessionTracker.db;";
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

    public static void CreateLog()
    {
        var sql = 
        $@"INSERT INTO coding_sessions (StartTime, EndTime, Duration)
            VALUES ('Fuck', 'Shit', 60)";
        connection.Execute(sql);
    }

    public static void SelectLog()
    {
        var sql = 
        $@"SELECT * FROM coding_sessions";
        var dataSet = connection.Query<SessionData>(sql).ToList();

        foreach (var data in dataSet)
        {
            Console.WriteLine($"{data.Id}\t{data.StartTime}\t{data.EndTime}\t{data.Duration}");
        }
    }

    public static void ExitDB()
    {
        connection.Close();
    }
}
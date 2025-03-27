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
            Duration TEXT)";
        
        connection.Execute(sql);
        
    }

    public static void InsertLog(SessionData data)
    {
        var sql = 
        $@"INSERT INTO coding_sessions (StartTime, EndTime, Duration)
            VALUES ('{data.StartTime}', '{data.EndTime}', '{data.Duration}')";
        connection.Execute(sql);
    }

    public static List<SessionData> SelectLog()
    {
        var sql = 
        $@"SELECT * FROM coding_sessions";
        return connection.Query<SessionData>(sql).ToList();
    }

    public static void UpdateLog(int id, SessionData newData)
    {
        var sql =
        $@"UPDATE coding_sessions
            SET StartTime = '{newData.StartTime}',
                EndTime = '{newData.EndTime}',
                Duration = '{newData.Duration}'
            WHERE Id = {id}";
        
        connection.Execute(sql);
    }

    public static void DeleteLog(int id)
    {
        var sql = 
        $@"DELETE FROM coding_sessions
            WHERE Id = {id}";
        
        connection.Execute(sql);
    }

    public static void ExitDB()
    {
        connection.Close();
    }
}
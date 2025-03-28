using Dapper;
using Microsoft.Data.Sqlite;
using System.Configuration;


class SessionDBModel
{
    static SqliteConnection connection = null;
    public static void CreateDB()
    {
        var connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
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

    public static List<SessionData> GetAllLog(string orderBy, bool desc = false)
    {
        var sql = 
        $@"SELECT * 
            FROM coding_sessions
            ORDER BY {orderBy}";
        
        if (desc)
            sql += " DESC";
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

    public static int[] GetIdFromDB()
    {
        var sql = 
        $@"SELECT * FROM coding_sessions";

        return connection.Query<int>(sql).ToArray();
    }
}
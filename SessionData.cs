
class SessionData
{
    public int Id { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string Duration { get; set; }
    
    public DateTime StartDateTime()
    {
        return DateTime.Parse(StartTime);
    }
    public DateTime EndDateTime()
    {
        return DateTime.Parse(EndTime);
    }
}

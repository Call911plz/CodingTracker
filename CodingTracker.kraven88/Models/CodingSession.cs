﻿namespace CodingTracker.kraven88.Models;

internal class CodingSession
{
    public int Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public TimeSpan Duration => End - Start;
}

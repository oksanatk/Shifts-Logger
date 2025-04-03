namespace ShiftsLogger.WebApi.Models;

internal class Shift
{
    internal int Id { get; set; }
    internal Worker Worker { get; set; } = null!;
    internal int WorkerId { get; set; }
    internal DateTime StartTime { get; set; } = new();
    internal DateTime EndTime { get; set; } = new();
    internal TimeSpan Duration
    {
        get
        {
            return EndTime - StartTime;
        }
    }
}
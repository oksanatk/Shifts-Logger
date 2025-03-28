namespace ShiftsLogger.WebApi.Models;

public class Shift
{
    public int Id { get; set; }
    public Worker Worker { get; set; } = null!;
    public int WorkerId { get; set; }
    public DateTime StartTime { get; set; } = new();
    public DateTime EndTime { get; set; } = new();
    public TimeSpan Duration
    {
        get
        {
            return EndTime - StartTime;
        }
    }
}
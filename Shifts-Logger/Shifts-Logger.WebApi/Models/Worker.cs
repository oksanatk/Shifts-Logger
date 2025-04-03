namespace ShiftsLogger.WebApi.Models;

internal class Worker
{
    internal int Id { get; set; }
    internal string Name { get; set; } = null!;
    internal List<Shift> Shifts { get; set; } = null!;
}

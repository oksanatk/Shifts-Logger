namespace ConsoleUI.Models;

internal class Worker
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public List<Shift> Shifts { get; set; } = new();
}

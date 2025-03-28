namespace Shifts_Logger.WebApi.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public Shift[] Shifts { get; set; } = null!;
    }
}

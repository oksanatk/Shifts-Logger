namespace Shifts_Logger.WebApi.Models
{
    public class Shift
    {
        public int Id { get; set; }
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
}
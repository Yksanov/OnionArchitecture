namespace Onion.Domain.Entities;

public class Schedule
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Day { get; set; }
}
namespace Onion.Domain.Entities;

public class TrialLesson
{
    public int Id { get; set; }
    
    public DateTime Date { get; set; }
    public int InvitedCount { get; set; }
    public int PassedCount { get; set; }
    public int CameCount { get; set; }
    public string Comment { get; set; } = String.Empty;
    public int TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
}
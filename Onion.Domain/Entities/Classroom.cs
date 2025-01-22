namespace Onion.Domain.Entities;

public class Classroom
{
    public int Id { get; set; }
    public int Capacity { get; set; }
    public bool IsAvailable { get; set; }
    
    public int BranchId { get; set; }
    public Branch? Branch { get; set; }
    
    public List<Group>? Groups { get; set; } = new List<Group>();
}
namespace Onion.Domain.Entities;

public class Branch
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    
    public List<Classroom>? Classrooms { get; set; } = new List<Classroom>();
}
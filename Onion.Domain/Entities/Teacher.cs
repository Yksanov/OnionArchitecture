namespace Onion.Domain.Entities;

public class Teacher
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public int LessonNameId { get; set; }
    public LessonName? LessonName { get; set; }
    
    public int BranchId { get; set; }
    public Branch? Branch { get; set; }

    public List<Group>? Groups { get; set; } = new List<Group>();
}
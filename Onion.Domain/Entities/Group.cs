namespace Onion.Domain.Entities;

public class Group
{
    public int Id { get; set; }
    
    public int ScheduleId { get; set; }
    public Schedule? Schedule { get; set; }
    
    public int ClassroomId { get; set; }
    public Classroom? Classroom { get; set; }
    
    public int GroupTypeId { get; set; }
    public GroupType? GroupType { get; set; }
    
    public int LessonNameId { get; set; }
    public LessonName? LessonName { get; set; }
    
    public int TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
    
    public List<Student>? Students { get; set; } = new List<Student>();
}
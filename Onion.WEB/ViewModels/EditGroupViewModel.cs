using Onion.Domain.Entities;

namespace OnionArhitectura.ViewModels;

public class EditGroupViewModel
{
    public int Id { get; set; }
    public int ScheduleId { get; set; }
    public int ClassroomId { get; set; }
    public int GroupTypeId { get; set; }
    public int LessonNameId { get; set; }
    public int TeacherId { get; set; }
    
    public List<Schedule> Schedules { get; set; }
    public List<Classroom> Classrooms { get; set; }
    public List<GroupType> GroupTypes { get; set; }
    public List<LessonName> LessonNames { get; set; }
    public List<Teacher> Teachers { get; set; }
}
namespace Onion.Domain.Entities;

public class Request
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime PreferredTime { get; set; }
    public string Phone { get; set; }
    
    public int GroupTypeId { get; set; }
    public GroupType? GroupType { get; set; }
    
    public int LessonNameId { get; set; }
    public LessonName? LessonName { get; set; }
}
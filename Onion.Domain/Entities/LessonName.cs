namespace Onion.Domain.Entities;

public class LessonName
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<Teacher>? Teachers { get; set; } = new List<Teacher>();
}
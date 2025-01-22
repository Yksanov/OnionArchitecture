namespace Onion.Domain.Entities;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public bool StudentType { get; set; }
    
    public int GroupId { get; set; }
    public Group? Group { get; set; }
}
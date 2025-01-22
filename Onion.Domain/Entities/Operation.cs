namespace Onion.Domain.Entities;

public class Operation
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Amount { get; set; }
    public string Currency { get; set; }
    public DateTime Date { get; set; }
    public string State { get; set; }
    
    public int StudentId { get; set; }
    public Student? Student { get; set; }
    
    public int OperationTypeId { get; set; }
    public OperationType? OperationType { get; set; }
    
    public int? TeacherFromId { get; set; }
    public Teacher? TeacherFrom { get; set; }
    
    public int? TeacherToId { get; set; }
    public Teacher? TeacherTo { get; set; }
}
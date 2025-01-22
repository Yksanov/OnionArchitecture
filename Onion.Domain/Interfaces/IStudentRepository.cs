using Onion.Domain.Entities;

namespace Onion.Domain.Interfaces;

public interface IStudentRepository
{
    Task AddStudentAsync(Student student);
    Task RemoveStudentAsync(Student student);
    Task<List<Student>> GetAllStudentsAsync();
    Task UpdateStudentAsync(Student student);
    Task<Student> GetStudentByIdAsync(int? id);
}
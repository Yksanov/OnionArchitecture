using Onion.Domain.Entities;

namespace Onion.Application.Interfaces;

public interface IStudentService
{
    Task AddStudentAsync(Student student);
    Task RemoveStudentAsync(Student student);
    Task<List<Student>> GetAllStudentsAsync();
    Task UpdateStudentAsync(Student student);
    Task<Student> GetStudentByIdAsync(int? id);
}
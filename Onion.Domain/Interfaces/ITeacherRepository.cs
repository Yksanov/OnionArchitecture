using Onion.Domain.Entities;

namespace Onion.Domain.Interfaces;

public interface ITeacherRepository
{
    Task<Teacher>? GetTeacherByIdAsync(int? id);
    Task<IEnumerable<Teacher>> GetTeachersAsync();
    Task AddTeacherAsync(Teacher teacher);
    Task UpdateTeacherAsync(Teacher teacher);
    Task DeleteTeacherAsync(Teacher teacher);
}
using Onion.Domain.Entities;

namespace Onion.Domain.Interfaces;

public interface IClassroomRepository
{
    Task AddClassroomAsync(Classroom classroom);
    Task RemoveClassroomAsync(Classroom classroom);
    Task<List<Classroom>> GetAllClassroomsAsync();
    Task UpdateClassroomAsync(Classroom classroom);
    Task<Classroom> GetClassroomByIdAsync(int id);
}
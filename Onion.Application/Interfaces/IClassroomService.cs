using Onion.Domain.Entities;

namespace Onion.Application.Interfaces;

public interface IClassroomService
{
    Task AddClassroomAsync(Classroom classroom);
    Task RemoveClassroomAsync(Classroom classroom);
    Task<List<Classroom>> GetAllClassroomsAsync();
    Task UpdateClassroomAsync(Classroom classroom);
    Task<Classroom> GetClassroomByIdAsync(int id);
}
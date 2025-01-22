using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;

namespace Onion.Application.Services;

public class ClassroomService : IClassroomService
{
    private readonly IClassroomRepository _repository;

    public ClassroomService(IClassroomRepository repository)
    {
        _repository = repository;
    }

    public async Task AddClassroomAsync(Classroom classroom)
    {
        await _repository.AddClassroomAsync(classroom);
    }

    public async Task RemoveClassroomAsync(Classroom classroom)
    {
        await _repository.RemoveClassroomAsync(classroom);
    }

    public async Task<List<Classroom>> GetAllClassroomsAsync()
    {
        return await _repository.GetAllClassroomsAsync();
    }

    public async Task UpdateClassroomAsync(Classroom classroom)
    {
        await _repository.UpdateClassroomAsync(classroom);
    }

    public async Task<Classroom> GetClassroomByIdAsync(int id)
    {
        return await _repository.GetClassroomByIdAsync(id);
    }
}
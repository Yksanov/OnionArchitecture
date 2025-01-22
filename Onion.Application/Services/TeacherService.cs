using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;

namespace Onion.Application.Services;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _repository;

    public TeacherService(ITeacherRepository repository)
    {
        _repository = repository;
    }

    public async Task<Teacher>? GetTeacherByIdAsync(int? id)
    {
        return await _repository.GetTeacherByIdAsync(id);
    }

    public async Task<IEnumerable<Teacher>> GetTeachersAsync()
    {
        return await _repository.GetTeachersAsync();
    }

    public async Task AddTeacherAsync(Teacher teacher)
    {
        await _repository.AddTeacherAsync(teacher);
    }

    public async Task UpdateTeacherAsync(Teacher teacher)
    {
        await _repository.UpdateTeacherAsync(teacher);
    }

    public async Task DeleteTeacherAsync(Teacher teacher)
    {
        await _repository.DeleteTeacherAsync(teacher);
    }
}
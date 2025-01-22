using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;

namespace Onion.Application.Services;

public class ScheduleService : IScheduleService
{
    private readonly IScheduleRepository _repository;

    public ScheduleService(IScheduleRepository repository)
    {
        _repository = repository;
    }

    public async Task AddScheduleAsync(Schedule schedule)
    {
        await _repository.AddScheduleAsync(schedule);
    }

    public async Task RemoveScheduleAsync(Schedule schedule)
    {
        await _repository.RemoveScheduleAsync(schedule);
    }

    public async Task<IEnumerable<Schedule>> GetAllSchedulesAsync()
    {
        return await _repository.GetAllSchedulesAsync();
    }

    public async Task UpdateScheduleAsync(Schedule schedule)
    {
        await _repository.UpdateScheduleAsync(schedule);
    }

    public async Task<Schedule> GetScheduleByIdAsync(int id)
    {
        return await _repository.GetScheduleByIdAsync(id);
    }
}
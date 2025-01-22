using Onion.Domain.Entities;

namespace Onion.Domain.Interfaces;

public interface IScheduleRepository
{
    Task AddScheduleAsync(Schedule schedule);
    Task RemoveScheduleAsync(Schedule schedule);
    Task<IEnumerable<Schedule>> GetAllSchedulesAsync();
    Task UpdateScheduleAsync(Schedule schedule);
    Task<Schedule> GetScheduleByIdAsync(int id);
}
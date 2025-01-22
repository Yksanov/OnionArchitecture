using Onion.Domain.Entities;

namespace Onion.Application.Interfaces;

public interface IScheduleService
{
    Task AddScheduleAsync(Schedule schedule);
    Task RemoveScheduleAsync(Schedule schedule);
    Task<IEnumerable<Schedule>> GetAllSchedulesAsync();
    Task UpdateScheduleAsync(Schedule schedule);
    Task<Schedule> GetScheduleByIdAsync(int id);
}
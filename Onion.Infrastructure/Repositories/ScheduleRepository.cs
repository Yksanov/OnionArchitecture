using Microsoft.EntityFrameworkCore;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;
using Onion.Infrastructure.Data;

namespace Onion.Infrastructure.Repositories;

public class ScheduleRepository : IScheduleRepository
{
    private readonly Context _context;

    public ScheduleRepository(Context context)
    {
        _context = context;
    }

    public async Task AddScheduleAsync(Schedule schedule)
    {
        await _context.Schedules.AddAsync(schedule);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveScheduleAsync(Schedule schedule)
    {
        _context.Schedules.Remove(schedule);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Schedule>> GetAllSchedulesAsync()
    {
        return await _context.Schedules.ToListAsync();
    }

    public async Task UpdateScheduleAsync(Schedule schedule)
    {
        _context.Schedules.Update(schedule);
        await _context.SaveChangesAsync();
    }

    public async Task<Schedule> GetScheduleByIdAsync(int id)
    {
        return await _context.Schedules.FirstOrDefaultAsync(x => x.Id == id);
    }
}
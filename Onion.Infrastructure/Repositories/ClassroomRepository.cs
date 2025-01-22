using Microsoft.EntityFrameworkCore;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;
using Onion.Infrastructure.Data;

namespace Onion.Infrastructure.Repositories;

public class ClassroomRepository : IClassroomRepository
{
    private readonly Context _context;

    public ClassroomRepository(Context context)
    {
        _context = context;
    }

    public async Task AddClassroomAsync(Classroom classroom)
    {
        await _context.Classrooms.AddAsync(classroom);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveClassroomAsync(Classroom classroom)
    {
        _context.Classrooms.Remove(classroom);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Classroom>> GetAllClassroomsAsync()
    {
        return await _context.Classrooms
            .Include(c => c.Branch)
            .Include(c => c.Groups).ToListAsync();
    }

    public async Task UpdateClassroomAsync(Classroom classroom)
    {
        _context.Classrooms.Update(classroom);
        await _context.SaveChangesAsync();
    }

    public async Task<Classroom> GetClassroomByIdAsync(int id)
    {
        return await _context.Classrooms
            .Include(c => c.Branch)
            .Include(c  =>c.Groups)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}
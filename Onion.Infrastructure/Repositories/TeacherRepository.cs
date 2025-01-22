using Microsoft.EntityFrameworkCore;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;
using Onion.Infrastructure.Data;

namespace Onion.Infrastructure.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly Context _context;

    public TeacherRepository(Context context)
    {
        _context = context;
    }

    public async Task<Teacher>? GetTeacherByIdAsync(int? id)
    {
        return await _context.Teachers.FindAsync(id);
    }

    public async Task<IEnumerable<Teacher>> GetTeachersAsync()
    {
        return await _context.Teachers
            .Include(t => t.LessonName)
            .Include(t => t.Branch)
            .Include(t => t.Groups)
            .ToListAsync();
    }

    public async Task AddTeacherAsync(Teacher teacher)
    {
        await _context.Teachers.AddAsync(teacher);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTeacherAsync(Teacher teacher)
    {
        _context.Teachers.Update(teacher);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTeacherAsync(Teacher teacher)
    {
        _context.Teachers.Remove(teacher);
        await _context.SaveChangesAsync();
    }
}
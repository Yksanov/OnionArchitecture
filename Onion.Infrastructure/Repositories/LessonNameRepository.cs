using Microsoft.EntityFrameworkCore;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;
using Onion.Infrastructure.Data;

namespace Onion.Infrastructure.Repositories;

public class LessonNameRepository : ILessonNameRepository
{
    private readonly Context _context;

    public LessonNameRepository(Context context)
    {
        _context = context;
    }

    public async Task AddLessonNameAsync(LessonName lessonName)
    {
        await _context.LessonNames.AddAsync(lessonName);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveLessonNameAsync(LessonName lessonName)
    {
        _context.LessonNames.Remove(lessonName);
        await _context.SaveChangesAsync();
    }

    public async Task<List<LessonName>> GetAllLessonNamesAsync()
    {
        return await _context.LessonNames.Include(l => l.Teachers).ToListAsync();
    }

    public async Task UpdateLessonNameAsync(LessonName lessonName)
    {
        _context.LessonNames.Update(lessonName);
        await _context.SaveChangesAsync();
    }

    public async Task<LessonName?> GetLessonNameByIdAsync(int? id)
    {
        return await _context.LessonNames.Include(l => l.Teachers).FirstOrDefaultAsync(l => l.Id == id);
    }
}
using Microsoft.EntityFrameworkCore;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;
using Onion.Infrastructure.Data;

namespace Onion.Infrastructure.Repositories;

public class TrialLessonRepository : ITrialLessonRepository
{
    private readonly Context _context;
        
    public async Task AddTrialLesson(TrialLesson trialLesson)
    {
        await _context.TrialLessons.AddAsync(trialLesson);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TrialLesson>> GetTrialLessons()
    {
        return await _context.TrialLessons
            .Include(t => t.Teacher)
            .Include(t => t.InvitedCount)
            .Include(t => t.PassedCount)
            .Include(t => t.CameCount)
            .Include(t => t.PassedCount)
            .OrderBy(t => t.Date)
            .ToListAsync();
    }

    public async Task UpdateTrialLesson(TrialLesson trialLesson)
    {
        _context.TrialLessons.Update(trialLesson);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveTrialLesson(TrialLesson trialLesson)
    {
        _context.TrialLessons.Remove(trialLesson);
        await _context.SaveChangesAsync();
    }

    public async Task<TrialLesson> GetTrialLessonById(int? id)
    {
        return await _context.TrialLessons.FindAsync(id);
    }
}
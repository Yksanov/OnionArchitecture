using Microsoft.EntityFrameworkCore;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;
using Onion.Infrastructure.Data;

namespace Onion.Infrastructure.Repositories;

public class GroupRepository : IGroupRepository
{
    private readonly Context _context;

    public GroupRepository(Context context)
    {
        _context = context;
    }

    public async Task<Group>? GetGroupByIdAsync(int? id)
    {
        return await _context.Groups.FindAsync(id);
    }

    public async Task<IEnumerable<Group>> GetGroupsAsync()
    {
        return await _context.Groups
            .Include(g => g.Schedule)
            .Include(g => g.Classroom)
            .Include(g => g.GroupType)
            .Include(g => g.LessonName)
            .Include(g => g.Teacher)
            .Include(g => g.Students).ToListAsync();
    }

    public async Task AddGroupAsync(Group group)
    {
        await _context.Groups.AddAsync(group);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateGroupAsync(Group group)
    {
        _context.Groups.Update(group);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteGroupAsync(Group group)
    {
        _context.Groups.Remove(group);
        await _context.SaveChangesAsync();
    }
}
using Microsoft.EntityFrameworkCore;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;
using Onion.Infrastructure.Data;

namespace Onion.Infrastructure.Repositories;

public class GroupTypeRepository : IGroupTypeRepository
{
    private readonly Context _context;

    public GroupTypeRepository(Context context)
    {
        _context = context;
    }

    public async Task AddGroupTypeAsync(GroupType groupType)
    {
        await _context.GroupTypes.AddAsync(groupType);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveGroupTypeAsync(GroupType groupType)
    {
        _context.GroupTypes.Remove(groupType);
        await _context.SaveChangesAsync();
    }

    public async Task<List<GroupType>> GetAllGroupTypesAsync()
    {
        return await _context.GroupTypes.ToListAsync();
    }

    public async Task UpdateGroupTypeAsync(GroupType groupType)
    {
        _context.Update(groupType);
        await _context.SaveChangesAsync();
    }

    public async Task<GroupType?> GetGroupTypeByIdAsync(int? id)
    {
        return await _context.GroupTypes.FirstOrDefaultAsync(c => c.Id == id);
    }
}
using Microsoft.EntityFrameworkCore;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;
using Onion.Infrastructure.Data;

namespace Onion.Infrastructure.Repositories;

public class BranchRepository : IBranchRepository
{
    private readonly Context _context;

    public BranchRepository(Context context)
    {
        _context = context;
    }

    public async Task AddBranchAsync(Branch branch)
    {
      _context.Branches.Entry(branch).State = EntityState.Added;
        await _context.SaveChangesAsync();
    }

    public async Task RemoveBranchAsync(Branch branch)
    {
        _context.Branches.Entry(branch).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }

    public async Task UpdateBranchAsync(Branch branch)
    {
        _context.Branches.Entry(branch).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<List<Branch>> GetAllBranchesAsync()
    {
        return await _context.Branches.Include(b => b.Classrooms).ToListAsync();
    }

    public async Task<Branch> GetBranchByIdAsync(int id)
    {
        return await _context.Branches.Include(b => b.Classrooms).FirstOrDefaultAsync(b => b.Id == id);
    }
}
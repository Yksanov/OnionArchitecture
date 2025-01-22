using Microsoft.EntityFrameworkCore;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;
using Onion.Infrastructure.Data;

namespace Onion.Infrastructure.Repositories;

public class OperationRepository : IOperationRepository
{
    private readonly Context _context;

    public OperationRepository(Context context)
    {
        _context = context;
    }

    public async Task AddOperationAsync(Operation operation)
    {
        await _context.Operations.AddAsync(operation);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Operation>> GetAllOperationsAsync()
    {
        return await _context.Operations
            .Include(o => o.OperationType)
            .Include(o => o.Student)
            .Include(o => o.TeacherFrom)
            .Include(o => o.TeacherTo)
            .ToListAsync();
    }

    public async Task<Operation?> GetOperationByIdAsync(int id)
    {
        return await _context.Operations
            .Include(o => o.OperationType)
            .Include(o => o.Student)
            .Include(o => o.TeacherFrom)
            .Include(o => o.TeacherTo)
            .FirstOrDefaultAsync(o => o.Id == id);
    }
}
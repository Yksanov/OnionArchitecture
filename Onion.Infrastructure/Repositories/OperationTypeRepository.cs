using Microsoft.EntityFrameworkCore;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;
using Onion.Infrastructure.Data;

namespace Onion.Infrastructure.Repositories;

public class OperationTypeRepository : IOperationTypeRepository
{
    private readonly Context _context;

    public OperationTypeRepository(Context context)
    {
        _context = context;
    }

    public async Task AddOperationTypeAsync(OperationType operationType)
    {
        await _context.OperationTypes.AddAsync(operationType);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveOperationTypeAsync(OperationType operationType)
    {
        _context.OperationTypes.Remove(operationType);
        await _context.SaveChangesAsync();
    }

    public async Task<List<OperationType>> GetAllOperationTypesAsync()
    {
        return await _context.OperationTypes.ToListAsync();
    }

    public async Task UpdateOperationTypeAsync(OperationType operationType)
    {
        _context.OperationTypes.Update(operationType);
        await _context.SaveChangesAsync();
    }

    public async Task<OperationType?> GetOperationTypeByIdAsync(int? id)
    {
        return await _context.OperationTypes.FirstOrDefaultAsync(c => c.Id == id);
    }
}
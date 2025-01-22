using Onion.Domain.Entities;

namespace Onion.Domain.Interfaces;

public interface IOperationTypeRepository
{
    Task AddOperationTypeAsync(OperationType operationType);
    Task RemoveOperationTypeAsync(OperationType operationType);
    Task<List<OperationType>> GetAllOperationTypesAsync();
    Task UpdateOperationTypeAsync(OperationType operationType);
    Task<OperationType?> GetOperationTypeByIdAsync(int? id);
}
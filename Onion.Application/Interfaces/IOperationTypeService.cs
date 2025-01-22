using Onion.Domain.Entities;

namespace Onion.Application.Interfaces;

public interface IOperationTypeService
{
    Task AddOperationTypeAsync(OperationType operationType);
    Task RemoveOperationTypeAsync(OperationType operationType);
    Task<List<OperationType>> GetAllOperationTypesAsync();
    Task UpdateOperationTypeAsync(OperationType operationType);
    Task<OperationType?> GetOperationTypeByIdAsync(int? id);
}
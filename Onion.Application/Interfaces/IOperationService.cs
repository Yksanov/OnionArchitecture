using Onion.Domain.Entities;

namespace Onion.Application.Interfaces;

public interface IOperationService
{
    Task AddOperationAsync(Operation operation);
    Task<List<Operation>> GetAllOperationsAsync();
    Task<Operation?> GetOperationByIdAsync(int id);
}
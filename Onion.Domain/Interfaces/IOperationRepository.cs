using Onion.Domain.Entities;

namespace Onion.Domain.Interfaces;

public interface IOperationRepository
{
    Task AddOperationAsync(Operation operation);
    Task<List<Operation>> GetAllOperationsAsync();
    Task<Operation?> GetOperationByIdAsync(int id);
}
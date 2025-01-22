using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;

namespace Onion.Application.Services;

public class OperationService : IOperationService
{
    public readonly IOperationRepository _operationRepository;

    public OperationService(IOperationRepository operationRepository)
    {
        _operationRepository = operationRepository;
    }

    public async Task AddOperationAsync(Operation operation)
    {
        if (string.IsNullOrWhiteSpace(operation.Description))
            throw new ArgumentException("Описание операции не может быть пустым.");

        if (string.IsNullOrWhiteSpace(operation.Amount))
            throw new ArgumentException("Сумма операции не может быть пустой.");

        await _operationRepository.AddOperationAsync(operation);
    }

    public async Task<List<Operation>> GetAllOperationsAsync()
    {
        return await _operationRepository.GetAllOperationsAsync();
    }

    public async Task<Operation?> GetOperationByIdAsync(int id)
    {
        return await _operationRepository.GetOperationByIdAsync(id);
    }
}
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;

namespace Onion.Application.Services;

public class OperationTypeService : IOperationTypeService
{
    private readonly IOperationTypeRepository _operationTypeRepository;

    public OperationTypeService(IOperationTypeRepository operationTypeRepository)
    {
        _operationTypeRepository = operationTypeRepository;
    }

    public async Task AddOperationTypeAsync(OperationType operationType)
    {
        await _operationTypeRepository.AddOperationTypeAsync(operationType);
    }

    public async Task RemoveOperationTypeAsync(OperationType operationType)
    {
        await _operationTypeRepository.RemoveOperationTypeAsync(operationType);
    }

    public async Task<List<OperationType>> GetAllOperationTypesAsync()
    {
        return await _operationTypeRepository.GetAllOperationTypesAsync();
    }

    public async Task UpdateOperationTypeAsync(OperationType operationType)
    {
        await _operationTypeRepository.UpdateOperationTypeAsync(operationType);
    }

    public async Task<OperationType?> GetOperationTypeByIdAsync(int? id)
    {
        return await _operationTypeRepository.GetOperationTypeByIdAsync(id);
    }
}
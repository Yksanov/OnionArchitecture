using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;

namespace Onion.Application.Services;

public class BranchService : IBranchService
{
    private readonly IBranchRepository _branchRepository;

    public BranchService(IBranchRepository branchRepository)
    {
        _branchRepository = branchRepository;
    }

    public async Task AddBranchAsync(Branch branch)
    {
       await _branchRepository.AddBranchAsync(branch);
    }

    public async Task RemoveBranchAsync(Branch branch)
    {
        await _branchRepository.RemoveBranchAsync(branch);
    }

    public async Task UpdateBranchAsync(Branch branch)
    {
        await _branchRepository.UpdateBranchAsync(branch);
    }

    public async Task<List<Branch>> GetAllBranchesAsync()
    {
        return await _branchRepository.GetAllBranchesAsync();
    }

    public async Task<Branch> GetBranchByIdAsync(int id)
    {
        return await _branchRepository.GetBranchByIdAsync(id);
    }
}
using Onion.Domain.Entities;

namespace Onion.Domain.Interfaces;

public interface IBranchRepository
{
    Task AddBranchAsync(Branch branch);
    Task RemoveBranchAsync(Branch branch);
    Task UpdateBranchAsync(Branch branch);
    Task<List<Branch>> GetAllBranchesAsync();
    Task<Branch> GetBranchByIdAsync(int id);
}
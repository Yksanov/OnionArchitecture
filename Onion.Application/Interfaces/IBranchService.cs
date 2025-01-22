using Onion.Domain.Entities;

namespace Onion.Application.Interfaces;

public interface IBranchService
{
    Task AddBranchAsync(Branch branch);
    Task RemoveBranchAsync(Branch branch);
    Task UpdateBranchAsync(Branch branch);
    Task<List<Branch>> GetAllBranchesAsync();
    Task<Branch> GetBranchByIdAsync(int id);
}
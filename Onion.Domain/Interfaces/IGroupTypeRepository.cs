using Onion.Domain.Entities;

namespace Onion.Domain.Interfaces;

public interface IGroupTypeRepository
{
    Task AddGroupTypeAsync(GroupType groupType);
    Task RemoveGroupTypeAsync(GroupType groupType);
    Task<List<GroupType>> GetAllGroupTypesAsync();
    Task UpdateGroupTypeAsync(GroupType groupType);
    Task<GroupType?> GetGroupTypeByIdAsync(int? id);
}
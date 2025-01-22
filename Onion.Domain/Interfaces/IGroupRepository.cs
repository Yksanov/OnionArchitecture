using Onion.Domain.Entities;

namespace Onion.Domain.Interfaces;

public interface IGroupRepository
{
    Task<Group>? GetGroupByIdAsync(int? id);
    Task<IEnumerable<Group>> GetGroupsAsync();
    Task AddGroupAsync(Group group);
    Task UpdateGroupAsync(Group group);
    Task DeleteGroupAsync(Group group);
}
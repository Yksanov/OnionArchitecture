using Onion.Domain.Entities;

namespace Onion.Application.Interfaces;

public interface IGroupService
{
    Task<Group>? GetGroupByIdAsync(int? id);
    Task<IEnumerable<Group>> GetGroupsAsync();
    Task AddGroupAsync(Group group);
    Task UpdateGroupAsync(Group group);
    Task DeleteGroupAsync(Group group);
}
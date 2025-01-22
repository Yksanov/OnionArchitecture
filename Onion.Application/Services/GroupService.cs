using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;

namespace Onion.Application.Services;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;

    public GroupService(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task<Group>? GetGroupByIdAsync(int? id)
    {
        return await _groupRepository.GetGroupByIdAsync(id);
    }

    public async Task<IEnumerable<Group>> GetGroupsAsync()
    {
        return await _groupRepository.GetGroupsAsync();
    }

    public async Task AddGroupAsync(Group group)
    {
        await _groupRepository.AddGroupAsync(group);
    }

    public async Task UpdateGroupAsync(Group group)
    {
        await _groupRepository.UpdateGroupAsync(group);
    }

    public async Task DeleteGroupAsync(Group group)
    {
        await _groupRepository.DeleteGroupAsync(group);
    }
}
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;

namespace Onion.Application.Services;

public class GroupTypeService : IGroupTypeService
{
    private readonly IGroupTypeRepository _groupTypeRepository;

    public GroupTypeService(IGroupTypeRepository groupTypeRepository)
    {
        _groupTypeRepository = groupTypeRepository;
    }

    public async Task AddGroupTypeAsync(GroupType groupType)
    {
        await _groupTypeRepository.AddGroupTypeAsync(groupType);
    }

    public async Task RemoveGroupTypeAsync(GroupType groupType)
    {
        await _groupTypeRepository.RemoveGroupTypeAsync(groupType);
    }

    public async Task<List<GroupType>> GetAllGroupTypesAsync()
    {
        return await _groupTypeRepository.GetAllGroupTypesAsync();
    }

    public async Task UpdateGroupTypeAsync(GroupType groupType)
    {
        await _groupTypeRepository.UpdateGroupTypeAsync(groupType);
    }

    public async Task<GroupType?> GetGroupTypeByIdAsync(int? id)
    {
        return await _groupTypeRepository.GetGroupTypeByIdAsync(id);
    }
}
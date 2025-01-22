using System.Formats.Asn1;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using OnionArhitectura.ViewModels;

namespace OnionArhitectura.Controllers;

public class GroupTypeController : Controller
{
    private readonly IGroupTypeService _groupTypeService;

    public GroupTypeController(IGroupTypeService groupTypeService)
    {
        _groupTypeService = groupTypeService;
    }

    public async Task<IActionResult> AllGroupTypes()
    {
        return View(await _groupTypeService.GetAllGroupTypesAsync());
    }

    public async Task<IActionResult> AddGroupType()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddGroupType(GroupTypeViewModel model)
    {
        if (ModelState.IsValid)
        {
            GroupType groupType = new GroupType()
            {
                Name = model.Name
            };
            await _groupTypeService.AddGroupTypeAsync(groupType);
            return RedirectToAction("AllGroupTypes");
        }
        return View(model);
    }

    public async Task<IActionResult> DeleteGroupType(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        
        GroupType? groupType = await _groupTypeService.GetGroupTypeByIdAsync(id.Value);
        if (groupType == null)
        {
            return NotFound();
        }
        return View(groupType);
    }

    [HttpPost, ActionName("DeleteGroupType")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteGroupTypeConfirmed(int? id)
    {
        GroupType? groupType = await _groupTypeService.GetGroupTypeByIdAsync(id);

        if (groupType != null)
        {
            await _groupTypeService.RemoveGroupTypeAsync(groupType);
        }
        return RedirectToAction("AllGroupTypes");
    }

    public async Task<IActionResult> EditGroupType(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        
        GroupType? groupType = await _groupTypeService.GetGroupTypeByIdAsync(id.Value);
        if (groupType == null)
        {
            return NotFound();
        }

        EditGroupTypeViewModel vm = new EditGroupTypeViewModel()
        {
            Id = groupType.Id,
            Name = groupType.Name
        };
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditGroupType(EditGroupTypeViewModel model)
    {
        if (ModelState.IsValid)
        {
            GroupType? groupType = await _groupTypeService.GetGroupTypeByIdAsync(model.Id);
            if (groupType == null)
            {
                return NotFound();
            }

            groupType.Name = model.Name;
            await _groupTypeService.UpdateGroupTypeAsync(groupType);
            return RedirectToAction("AllGroupTypes");
        }

        return View(model);
    }
}
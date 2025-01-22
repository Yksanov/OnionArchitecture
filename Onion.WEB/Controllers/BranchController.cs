using Microsoft.AspNetCore.Mvc;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using OnionArhitectura.ViewModels;

namespace OnionArhitectura.Controllers;

public class BranchController : Controller
{
    private readonly IBranchService _branchService;

    public BranchController(IBranchService branchService)
    {
        _branchService = branchService;
    }

    public async Task<IActionResult> AllBranches()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> CreateBranch()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateBranch(BranchViewModel model)
    {
        if (ModelState.IsValid)
        {
            Branch branch = new Branch()
            {
                Name = model.Name,
                Location = model.Location
            };
            await _branchService.AddBranchAsync(branch);
            return RedirectToAction("AllBranches");
        }
        return View(model);
    }


    [HttpGet]
    public async Task<IActionResult> Remove(int id)
    {
        if (id == 0)
        {
            return NotFound();
        }
        Branch branch = await _branchService.GetBranchByIdAsync(id);
        if (branch == null)
        {
            return NotFound();
        }
        return View(branch);
    }

    [HttpPost]
    public async Task<IActionResult> RemoveBranch(int id)
    {
        Branch branch = await _branchService.GetBranchByIdAsync(id);

        if (branch == null)
        {
            return NotFound();
        }
        await _branchService.RemoveBranchAsync(branch);
        return RedirectToAction("AllBranches");
    }
}
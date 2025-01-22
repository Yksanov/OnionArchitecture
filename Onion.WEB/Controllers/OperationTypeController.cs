using Microsoft.AspNetCore.Mvc;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using OnionArhitectura.ViewModels;

namespace OnionArhitectura.Controllers;

public class OperationTypeController : Controller
{
    private readonly IOperationTypeService _operationTypeService;

    public OperationTypeController(IOperationTypeService operationTypeService)
    {
        _operationTypeService = operationTypeService;
    }

    public async Task<IActionResult> AllOperationTypes()
    {
        return View(await _operationTypeService.GetAllOperationTypesAsync());
    }

    public async Task<IActionResult> AddOperationType()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddOperationType(OperationTypeViewModel model)
    {
        if (ModelState.IsValid)
        {
            OperationType operationType = new OperationType()
            {
                Name = model.Name
            };
            await _operationTypeService.AddOperationTypeAsync(operationType);
            return RedirectToAction("AllOperationTypes");
        }

        return View(model);
    }

    public async Task<IActionResult> DeleteOperationType(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        OperationType operationType = await _operationTypeService.GetOperationTypeByIdAsync(id.Value);

        if (operationType == null)
        {
            return NotFound();
        }
        
        return View(operationType);
    }

    [HttpPost, ActionName("DeleteOperationType")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteOperationTypeConfirmed(int? id)
    {
        OperationType? operationType = await _operationTypeService.GetOperationTypeByIdAsync(id.Value);
        if (operationType != null)
        {
            await _operationTypeService.RemoveOperationTypeAsync(operationType);
        }
        return RedirectToAction("AllOperationTypes");
    }

    public async Task<IActionResult> EditOperationType(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        
        OperationType? operationType = await _operationTypeService.GetOperationTypeByIdAsync(id.Value);
        if (operationType == null)
        {
            return NotFound();
        }

        EditOperationTypeViewModel vm = new EditOperationTypeViewModel()
        {
            Id = operationType.Id,
            Name = operationType.Name
        };
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditOperationType(EditOperationTypeViewModel model)
    {
        if (ModelState.IsValid)
        {
            OperationType? operationType = await _operationTypeService.GetOperationTypeByIdAsync(model.Id);
            if (operationType == null)
            {
                return NotFound();
            }
            operationType.Name = model.Name;
            await _operationTypeService.UpdateOperationTypeAsync(operationType);
            return RedirectToAction("AddOperationType");
        }

        return View(model);
    }
}
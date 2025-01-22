using Microsoft.AspNetCore.Mvc;
using Onion.Application.Services;

namespace OnionArhitectura.Controllers;

public class OperationController : Controller
{
    private readonly OperationService _operationService;

    public OperationController(OperationService operationService)
    {
        _operationService = operationService;
    }

    public async Task<IActionResult> Index()
    {
        var operations = await _operationService.GetAllOperationsAsync();
        return View(operations);
    }
}
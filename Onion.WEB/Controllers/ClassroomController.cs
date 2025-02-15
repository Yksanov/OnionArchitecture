using Microsoft.AspNetCore.Mvc;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using OnionArhitectura.ViewModels;

namespace OnionArhitectura.Controllers;

public class ClassroomController : Controller
{
    private readonly IClassroomService _classroomService;

    public ClassroomController(IClassroomService classroomService)
    {
        _classroomService = classroomService;
    }

    public async Task<IActionResult> AllClassrooms()
    {
        return View(await _classroomService.GetAllClassroomsAsync());
    }

    [HttpGet]
    public IActionResult CreateClassroom()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateClassroom(ClassroomViewModel model)
    {
        if (ModelState.IsValid)
        {
            Classroom classroom = new Classroom()
            {
                Capacity = model.Capacity,
                BranchId = model.BranchId,
                IsAvailable = true
            };
            await _classroomService.AddClassroomAsync(classroom);
            return RedirectToAction("AllClassrooms");
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult RemoveClassroom()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoveClassroom(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Classroom? classroom = await _classroomService.GetClassroomByIdAsync(id.Value);
        if (classroom == null)
        {
            return NotFound();
        }
        await _classroomService.RemoveClassroomAsync(classroom);
        return RedirectToAction("AllClassrooms");
    }

    [HttpPost]
    public async Task<IActionResult> EditClassroom(Classroom classroom)
    {
        if (classroom == null)
        {
            return NotFound();
        }

        await _classroomService.UpdateClassroomAsync(classroom);
        return RedirectToAction("AllClassrooms");
    }
}
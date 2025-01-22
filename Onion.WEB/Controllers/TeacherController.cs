using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using OnionArhitectura.ViewModels;

namespace OnionArhitectura.Controllers;

public class TeacherController : Controller
{
    private readonly ITeacherService _teacherService;

    public TeacherController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    public async Task<IActionResult> AllTeachers()
    {
        var teachers = await _teacherService.GetTeachersAsync();

        var model = teachers.Select(t => new TeacherViewModel
        {
            Id = t.Id,
            FirstName = t.FirstName,
            LastName = t.LastName,
            LessonNameId = t.LessonNameId,
            BranchId = t.BranchId,
        });
        
        return View(model);
    }

    public async Task<IActionResult> AddTeacher()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddTeacher(TeacherViewModel model)
    {
        if (ModelState.IsValid)
        {
            Teacher teacher = new Teacher()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                BranchId = model.BranchId,
                LessonNameId = model.LessonNameId,
            };
            await _teacherService.AddTeacherAsync(teacher);
            return RedirectToAction("AllTeachers");
        }
        return View(model);
    }

    public async Task<IActionResult> DeleteTeacher(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Teacher teacher = await _teacherService.GetTeacherByIdAsync(id.Value);
        if (teacher == null)
        {
            return NotFound();
        }

        return View(teacher);
    }

    [HttpPost, ActionName("DeleteTeacher")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteTeacherConfirmed(int? id)
    {
        Teacher teacher = await _teacherService.GetTeacherByIdAsync(id.Value);
        if (teacher != null)
        {
            await _teacherService.DeleteTeacherAsync(teacher);
        }

        return RedirectToAction("AllTeachers");
    }

    public async Task<IActionResult> EditTeacher(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        
        Teacher teacher = await _teacherService.GetTeacherByIdAsync(id.Value);
        if (teacher == null)
        {
            return NotFound();
        }

        EditTeacherViewModel model = new EditTeacherViewModel()
        {
            Id = teacher.Id,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            BranchId = teacher.BranchId,
            LessonNameId = teacher.LessonNameId,
        };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditTeacher(EditTeacherViewModel model)
    {
        if (ModelState.IsValid)
        {
            Teacher teacher = await _teacherService.GetTeacherByIdAsync(model.Id);
            if (teacher == null)
            {
                return NotFound();
            }
            
            teacher.FirstName = model.FirstName;
            teacher.LastName = model.LastName;
            teacher.BranchId = model.BranchId;
            teacher.LessonNameId = model.LessonNameId;
            await _teacherService.UpdateTeacherAsync(teacher);
            return RedirectToAction("AllTeachers");
        }

        return View(model);
    }
}
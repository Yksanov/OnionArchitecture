using Microsoft.AspNetCore.Mvc;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using OnionArhitectura.ViewModels;

namespace OnionArhitectura.Controllers;

public class StudentController : Controller
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public async Task<IActionResult> AllStudents()
    {
        return View(await _studentService.GetAllStudentsAsync());
    }

    [HttpGet]
    public IActionResult CreateStudent()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateStudent(StudentViewModel model)
    {
        if (ModelState.IsValid)
        {
            Student student = new Student()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone,
                GroupId = model.GroupId,
                Description = model.Description,
                StudentType = true
            };
            await _studentService.AddStudentAsync(student);
            return RedirectToAction("AllStudents");
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult RemoveStudent()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoveStudent(int id)
    {
        if (id == 0)
        {
            return NotFound();
        }
        Student student = await _studentService.GetStudentByIdAsync(id);

        if (student == null)
        {
            return NotFound();
        }

        await _studentService.RemoveStudentAsync(student);
        return RedirectToAction("AllStudents");
    }
}
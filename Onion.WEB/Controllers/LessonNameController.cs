using Microsoft.AspNetCore.Mvc;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using OnionArhitectura.ViewModels;

namespace OnionArhitectura.Controllers;

public class LessonNameController : Controller
{
    private readonly ILessonNameService _lessonNameService;

    public LessonNameController(ILessonNameService lessonNameService)
    {
        _lessonNameService = lessonNameService;
    }

    public async Task<IActionResult> AllLessonNames()
    {
        return View(await _lessonNameService.GetAllLessonNamesAsync());
    }

    public async Task<IActionResult> AddLessonName()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddLessonName(LessonNameViewModel model)
    {
        if (ModelState.IsValid)
        {
            LessonName lessonName = new LessonName()
            {
                Name = model.Name
            };
            await _lessonNameService.AddLessonNameAsync(lessonName);
            return RedirectToAction("AllLessonNames");
        }
        return View(model);
    }

    public async Task<IActionResult> DeleteLessonName(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        LessonName lessonName = await _lessonNameService.GetLessonNameByIdAsync(id.Value);

        if (lessonName == null)
        {
            return NotFound();
        }

        return View(lessonName);
    }

    [HttpPost, ActionName("DeleteLessonName")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteLessonNameConfirmed(int? id)
    {
        LessonName? lessonName = await _lessonNameService.GetLessonNameByIdAsync(id.Value);
        if (lessonName != null)
        {
            await _lessonNameService.RemoveLessonNameAsync(lessonName);
        }
        return RedirectToAction("AllLessonNames");
    }


    public async Task<IActionResult> EditLessonName(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        LessonName? lessonName = await _lessonNameService.GetLessonNameByIdAsync(id.Value);

        if (lessonName == null)
        {
            return NotFound();
        }

        EditLessonNameViewModel vm = new EditLessonNameViewModel()
        {
            Id = lessonName.Id,
            Name = lessonName.Name
        };
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditLessonName(EditLessonNameViewModel model)
    {
        if (ModelState.IsValid)
        {
            LessonName? lessonName = await _lessonNameService.GetLessonNameByIdAsync(model.Id);
            if (lessonName == null)
            {
                return NotFound();
            }

            lessonName.Name = model.Name;
            await _lessonNameService.UpdateLessonNameAsync(lessonName);
            return RedirectToAction("AllLessonNames");
        }
        return View(model);
    }
}
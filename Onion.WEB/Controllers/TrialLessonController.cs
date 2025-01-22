using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using OnionArhitectura.ViewModels;

namespace OnionArhitectura.Controllers;

public class TrialLessonController : Controller
{
    private readonly ITrialLessonService _trialLessonService;

    public TrialLessonController(ITrialLessonService trialLessonService)
    {
        _trialLessonService = trialLessonService;
    }

    public async Task<IActionResult> AllTrialLessons()
    {
        return View(await _trialLessonService.GetTrialLessons());
    }
    
    public async Task<IActionResult> AddTrialLesson()
    {
      return View();  
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddTrialLesson(TrialLessonViewModel model)
    {
        if (ModelState.IsValid)
        {
            TrialLesson trialLesson = new TrialLesson()
            {
                Date = model.Date,
                InvitedCount = model.InvitedCount,
                CameCount = model.CameCount,
                PassedCount = model.PassedCount,
                Comment = model.Comment,
                TeacherId = model.TeacherId,
            };
            await _trialLessonService.AddTrialLesson(trialLesson);
            return RedirectToAction("AllTrialLessons");
        }
        return View(model);
    }

    public async Task<IActionResult> EditTrialLesson(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        
        TrialLesson trialLesson = await _trialLessonService.GetTrialLessonById(id.Value);
        if (trialLesson == null)
        {
            return NotFound();
        }

        TrialLessonViewModel model = new TrialLessonViewModel()
        {
            Id = trialLesson.Id,
            Date = trialLesson.Date,
            InvitedCount = trialLesson.InvitedCount,
            CameCount = trialLesson.CameCount,
            PassedCount = trialLesson.PassedCount,
            Comment = trialLesson.Comment,
            TeacherId = trialLesson.TeacherId,
        };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditTrialLesson(TrialLessonViewModel model)
    {
        if (ModelState.IsValid)
        {
            TrialLesson trialLesson = await _trialLessonService.GetTrialLessonById(model.Id);
            if (trialLesson == null)
            {
                return NotFound();
            }
            
            trialLesson.Date = model.Date;
            trialLesson.InvitedCount = model.InvitedCount;
            trialLesson.CameCount = model.CameCount;
            trialLesson.PassedCount = model.PassedCount;
            trialLesson.Comment = model.Comment;
            trialLesson.TeacherId = model.TeacherId;
            
            await _trialLessonService.UpdateTrialLesson(trialLesson);
            return RedirectToAction("AllTrialLessons");
        }
        return View(model);
    }

    public async Task<IActionResult> DeleteTrialLesson(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        
        TrialLesson trialLesson = await _trialLessonService.GetTrialLessonById(id.Value);
        if (trialLesson == null)
        {
            return NotFound();
        }
        
        return View(trialLesson);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteTrialLessonConfirmed(int id)
    {
        TrialLesson trialLesson = await _trialLessonService.GetTrialLessonById(id);
        if (trialLesson != null)
        {
            await _trialLessonService.RemoveTrialLesson(trialLesson);
        }
        return RedirectToAction("AllTrialLessons");
    }
}
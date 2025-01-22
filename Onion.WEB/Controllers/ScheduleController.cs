using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using OnionArhitectura.ViewModels;

namespace OnionArhitectura.Controllers;

public class ScheduleController : Controller
{
    private readonly IScheduleService _scheduleService;

    public ScheduleController(IScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }

    public async Task<IActionResult> AllSchedules()
    {
        return View(await _scheduleService.GetAllSchedulesAsync());
    }

    public async Task<IActionResult> AddSchedule()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddSchedule(CreateScheduleViewModel model)
    {
        if (ModelState.IsValid)
        {
            Schedule schedule = new Schedule()
            {
                StartTime = model.StartDate,
                EndTime = model.EndDate,
                Day = GetSelectedDay(model)
            };
            await _scheduleService.AddScheduleAsync(schedule);
            return RedirectToAction("AllSchedules");
        }

        return View(model);
    }
    
    public async Task<IActionResult> EditSchedule(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Schedule? schedule = await _scheduleService.GetScheduleByIdAsync(id.Value);
        if (schedule == null)
        {
            return NotFound();
        }

        EditScheduleViewModel vm = new EditScheduleViewModel()
        {
            Id = schedule.Id,
            StartDate = schedule.StartTime,
            EndDate = schedule.EndTime
        };

        PopulateDays(vm, schedule.Day);
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditSchedule(EditScheduleViewModel model)
    {
        if (ModelState.IsValid)
        {
            Schedule schedule = await _scheduleService.GetScheduleByIdAsync(model.Id);
            schedule.Day = GeneratedDaysString(model);
            schedule.StartTime = model.StartDate;
            schedule.EndTime = model.EndDate;
            await _scheduleService.UpdateScheduleAsync(schedule);
            return RedirectToAction("AllSchedules");
        }

        return View(model);
    }

    public async Task<IActionResult> DeleteSchedule(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Schedule? schedule = await _scheduleService.GetScheduleByIdAsync(id.Value);
        if (schedule == null)
        {
            return NotFound();
        }

        return View(schedule);
    }

    [HttpPost, ActionName("DeleteSchedule")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteScheduleConfirmed(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Schedule? schedule = await _scheduleService.GetScheduleByIdAsync(id.Value);
        if (schedule != null)
        {
            await _scheduleService.RemoveScheduleAsync(schedule);
            return RedirectToAction("AllSchedules");
        }
        return RedirectToAction("AllSchedules");
    }

//---------------------------------------------------------------------------
    private string GetSelectedDay(CreateScheduleViewModel model)
    {
        List<string> days = new List<string>();
        if (model.Monday) days.Add("Monday");
        if (model.Tuesday) days.Add("Tuesday");
        if (model.Wednesday) days.Add("Wednesday");
        if(model.Thursday) days.Add("Thursday");
        if (model.Friday) days.Add("Friday");
        if (model.Saturday) days.Add("Saturday");
        if(model.Sunday) days.Add("Sunday");
        return string.Join(", ", days);
    }
    
    private void PopulateDays(EditScheduleViewModel model, string days)
    {
        string[] selectedDays = days.Split(',');
        model.Monday = selectedDays.Contains("Mon");
        model.Tuesday = selectedDays.Contains("Tue");
        model.Wednesday = selectedDays.Contains("Wed");
        model.Thursday = selectedDays.Contains("Thu");
        model.Friday = selectedDays.Contains("Fri");
        model.Saturday = selectedDays.Contains("Sat");
        model.Sunday = selectedDays.Contains("Sun");
    }
    
    private string GeneratedDaysString(EditScheduleViewModel model)
    {
        var selectedDays = new List<string>();
        
        if(model.Monday) selectedDays.Add("Mon");
        if(model.Tuesday) selectedDays.Add("Tue");
        if(model.Wednesday) selectedDays.Add("Wed");
        if(model.Thursday) selectedDays.Add("Thu");
        if(model.Friday) selectedDays.Add("Fri");
        if(model.Saturday) selectedDays.Add("Sat");
        if(model.Sunday) selectedDays.Add("Sun");
        
        return string.Join(", ", selectedDays);
    }
}
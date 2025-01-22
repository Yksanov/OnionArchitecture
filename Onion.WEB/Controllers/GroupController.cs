using Microsoft.AspNetCore.Mvc;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using OnionArhitectura.ViewModels;

namespace OnionArhitectura.Controllers;

public class GroupController : Controller
{
    private readonly IGroupService _groupService;
    private readonly ITeacherService _teacherService;
    private readonly IClassroomService _classroomService;
    private readonly IGroupTypeService _groupTypeService;
    private readonly ILessonNameService _lessonNameService;
    private readonly IScheduleService _scheduleService;

    public GroupController(IGroupService groupService, ITeacherService teacherService, IClassroomService classroomService, IGroupTypeService groupTypeService, ILessonNameService lessonNameService, IScheduleService scheduleService)
    {
        _groupService = groupService;
        _teacherService = teacherService;
        _classroomService = classroomService;
        _groupTypeService = groupTypeService;
        _lessonNameService = lessonNameService;
        _scheduleService = scheduleService;
    }

    public async Task<IActionResult> AllGroups()
    {
        return View(await _groupService.GetGroupsAsync());
    }

    public async Task<IActionResult> AddGroup()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddGroup(CreateGroupViewModel model)
    {
        if (ModelState.IsValid)
        {
            Group group = new Group()
            {
                ScheduleId = model.ScheduleId,
                ClassroomId = model.ClassroomId,
                GroupTypeId = model.GroupTypeId,
                LessonNameId = model.LessonNameId,
                TeacherId = model.TeacherId
            };
            await _groupService.AddGroupAsync(group);
            return RedirectToAction("AllGroups");
        }
        model.Schedules = (await _scheduleService.GetAllSchedulesAsync()).ToList();
        model.LessonNames = await _lessonNameService.GetAllLessonNamesAsync();
        model.GroupTypes = await _groupTypeService.GetAllGroupTypesAsync();
        model.Classrooms = await _classroomService.GetAllClassroomsAsync();
        model.Teachers = (await _teacherService.GetTeachersAsync()).ToList();
        return View(model);
    }

    public async Task<IActionResult> EditGroup(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        Group? group = await _groupService.GetGroupByIdAsync(id.Value);
        if (group == null)
        {
            return NotFound();
        }

        EditGroupViewModel vm = new EditGroupViewModel()
        {
            Id = group.Id,
            ScheduleId = group.ScheduleId,
            ClassroomId = group.ClassroomId,
            GroupTypeId = group.GroupTypeId,
            LessonNameId = group.LessonNameId,
            TeacherId = group.TeacherId,
            Schedules = (await _scheduleService.GetAllSchedulesAsync()).ToList(),
            LessonNames = await _lessonNameService.GetAllLessonNamesAsync(),
            GroupTypes = await _groupTypeService.GetAllGroupTypesAsync(),
            Classrooms = await _classroomService.GetAllClassroomsAsync(),
            Teachers = (await _teacherService.GetTeachersAsync()).ToList()
        };
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditGroup(EditGroupViewModel model)
    {
        if (ModelState.IsValid)
        {
            Group? group = await _groupService.GetGroupByIdAsync(model.Id);
            if (group == null)
            {
                return NotFound();
            }
            
            group.ScheduleId = model.ScheduleId;
            group.ClassroomId = model.ClassroomId;
            group.GroupTypeId = model.GroupTypeId;
            group.LessonNameId = model.LessonNameId;
            group.TeacherId = model.TeacherId;

            await _groupService.UpdateGroupAsync(group);
            return RedirectToAction("AllGroups");
        }
        
        model.Schedules = (await _scheduleService.GetAllSchedulesAsync()).ToList(); 
        model.LessonNames = await _lessonNameService.GetAllLessonNamesAsync();
        model.GroupTypes = await _groupTypeService.GetAllGroupTypesAsync();
        model.Classrooms = await _classroomService.GetAllClassroomsAsync();
        model.Teachers = (await _teacherService.GetTeachersAsync()).ToList();
        return View(model);
    }

    public async Task<IActionResult> DeleteGroup(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        Group? group = await _groupService.GetGroupByIdAsync(id.Value);
         if (group == null)
         {
             return NotFound();
         }
         return View(group);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteGroupById(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        Group? group = await _groupService.GetGroupByIdAsync(id.Value);
        if (group != null)
        {
            await _groupService.DeleteGroupAsync(group);
        }
        return RedirectToAction("AllGroups");
    }
}
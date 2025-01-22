using Microsoft.AspNetCore.Mvc;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using OnionArhitectura.ViewModels;

namespace OnionArhitectura.Controllers;

public class NotificationTypeController : Controller
{
     private readonly INotificationTypeService _notificationTypeService;

     public NotificationTypeController(INotificationTypeService notificationTypeService)
     {
          _notificationTypeService = notificationTypeService;
     }

     public async Task<IActionResult> AllNotificationTypes()
     {
          return View(await _notificationTypeService.GetAllNotificationTypesAsync());
     }

     [HttpGet]
     public async Task<IActionResult> CreateNotificationType()
     {
          return View();
     }

     [HttpPost]
     public async Task<IActionResult> CreateNotificationType(NotificationTypeViewModel model)
     {
          if (ModelState.IsValid)
          {
               NotificationType notificationType = new NotificationType()
               {
                    Name = model.Name,
               };
               await _notificationTypeService.AddNotificationTypeAsync(notificationType);
               return RedirectToAction("AllNotificationTypes");
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
          NotificationType notificationType = await _notificationTypeService.GetNotificationTypeByIdAsync(id);
          if (notificationType == null)
          {
               return NotFound();
          }

          return View(notificationType);
     }


     [HttpPost]
     public async Task<IActionResult> RemoveNotificationType(int id)
     {
          NotificationType notificationType = await _notificationTypeService.GetNotificationTypeByIdAsync(id);
          if (notificationType == null)
          {
               return NotFound();
          }

          await _notificationTypeService.RemoveNotificationTypeAsync(notificationType);
          return RedirectToAction("AllNotificationTypes");
     }
}
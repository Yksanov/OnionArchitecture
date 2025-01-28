using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using OnionArhitectura.ViewModels;

namespace OnionArhitectura.Controllers;

[Authorize]

public class NotificationController : Controller
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public async Task<IActionResult> AllNotifications()
    {
        return View(await _notificationService.GetAllNotificationsAsync());
    }

    [HttpGet]
    public IActionResult AddNotification()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddNotification(NotificationViewModel model)
    {
        if (ModelState.IsValid)
        {
            Notification notification = new Notification
            {
                Text = model.Text,
                NotificationTypeId = model.NotificationTypeId
            };
            await _notificationService.AddNotificationAsync(notification);
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> RemoveNotification(int id)
    {
        if (id == 0)
        {
            return NotFound();
        }

        Notification notification = await _notificationService.GetNotificationByIdAsync(id);
        if (notification == null)
        {
            return NotFound();
        }

        await _notificationService.RemoveNotificationAsync(notification);

        return RedirectToAction("AllNotifications");
    }

    [HttpGet]
    public async Task<IActionResult> EditNotification(int id)
    {
        if (id == 0)
        {
            return NotFound();
        }

        Notification notification = await _notificationService.GetNotificationByIdAsync(id);
        if (notification == null)
        {
            return NotFound();
        }

        NotificationViewModel model = new NotificationViewModel()
        {
            Text = notification.Text,
            NotificationTypeId = notification.NotificationTypeId
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EditNotification(NotificationViewModel model, int id)
    {
        if (id == 0)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            Notification notification = await _notificationService.GetNotificationByIdAsync(id);
            notification.Text = model.Text;
            notification.NotificationTypeId = model.NotificationTypeId;
            await _notificationService.UpdateNotificationAsync(notification);
            return RedirectToAction("AllNotifications");
        }

        return View(model);
    }
}
using System.Diagnostics.Contracts;
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

    [NonAction]
    private async Task<int> GetUnreadNotifications()
    {
        List<Notification> notifications = await _notificationService.GetAllNotificationsAsync();
        int count = notifications.Count(n => n.IsRead == false);
        return count;
    }

    [HttpGet]
    public async Task<IActionResult> CheckForUnreadNotifications()
    {
        int count = await GetUnreadNotifications();
        if (count == 0)
        {
            return Json(new { success = false });
        }

        return Json(new { success = true, unreadCount = count });
    }

    [HttpPost]
    public async Task<IActionResult> MarkAsRead(int id)
    {
        Notification notification = await _notificationService.GetNotificationByIdAsync(id);
        if (notification.IsRead == false)
        {
            notification.IsRead = true;
            await _notificationService.UpdateNotificationAsync(notification);
            int count = await GetUnreadNotifications();
            return Json(new { success = "true", unreadCount = count });
        }

        return Json(new { success = "false" });
    }

    [HttpGet]
    public async Task<IActionResult> MarkAllAsRead()
    {
        List<Notification> notifications = await _notificationService.GetAllNotificationsAsync();
        List<Notification> unreadNotifications = notifications.FindAll(n => n.IsRead == false);
        if (unreadNotifications.Count > 0)
        {
            unreadNotifications.ForEach(n => n.IsRead = true);
            foreach (var notification in unreadNotifications)
            {
                await _notificationService.UpdateNotificationAsync(notification);
            }
        }

        return RedirectToAction("AllNotifications");
    }
}
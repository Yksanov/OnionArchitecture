using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;

namespace Onion.Application.Services;

public class NotificationService : INotificationService
{
    private readonly INotificationRepository _notificationRepository;

    public NotificationService(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task AddNotificationAsync(Notification notification)
    {
        await _notificationRepository.AddNotificationAsync(notification);
    }

    public async Task RemoveNotificationAsync(Notification notification)
    {
        await _notificationRepository.RemoveNotificationAsync(notification);
    }

    public async Task<List<Notification>> GetAllNotificationsAsync()
    {
        return await _notificationRepository.GetAllNotificationsAsync();
    }

    public async Task UpdateNotificationAsync(Notification notification)
    {
        await _notificationRepository.UpdateNotificationAsync(notification);
    }

    public async Task<Notification> GetNotificationByIdAsync(int id)
    {
        return await _notificationRepository.GetNotificationByIdAsync(id);
    }
}
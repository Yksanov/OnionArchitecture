using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;

namespace Onion.Application.Services;

public class NotificationTypeService : INotificationTypeService
{
    private readonly INotificationTypeRepository _notificationTypeRepository;

    public NotificationTypeService(INotificationTypeRepository notificationTypeRepository)
    {
        _notificationTypeRepository = notificationTypeRepository;
    }

    public async Task AddNotificationTypeAsync(NotificationType notificationType)
    {
        await _notificationTypeRepository.AddNotificationTypeAsync(notificationType);
    }

    public async Task RemoveNotificationTypeAsync(NotificationType notificationType)
    {
        await _notificationTypeRepository.RemoveNotificationTypeAsync(notificationType);
    }

    public async Task<List<NotificationType>> GetAllNotificationTypesAsync()
    {
        return await _notificationTypeRepository.GetAllNotificationTypesAsync();
    }

    public async Task UpdateNotificationTypeAsync(NotificationType notificationType)
    {
        await _notificationTypeRepository.UpdateNotificationTypeAsync(notificationType);
    }

    public async Task<NotificationType?> GetNotificationTypeByIdAsync(int id)
    {
        return await _notificationTypeRepository.GetNotificationTypeByIdAsync(id);
    }
}
using Onion.Domain.Entities;

namespace Onion.Application.Interfaces;

public interface INotificationTypeService
{
    Task AddNotificationTypeAsync(NotificationType notificationType);
    Task RemoveNotificationTypeAsync(NotificationType notificationType);
    Task<List<NotificationType>> GetAllNotificationTypesAsync();
    Task UpdateNotificationTypeAsync(NotificationType notificationType);
    Task<NotificationType?> GetNotificationTypeByIdAsync(int id);
}
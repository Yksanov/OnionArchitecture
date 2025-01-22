using Onion.Domain.Entities;

namespace Onion.Domain.Interfaces;

public interface INotificationTypeRepository
{
    Task AddNotificationTypeAsync(NotificationType notificationType);
    Task RemoveNotificationTypeAsync(NotificationType notificationType);
    Task<List<NotificationType>> GetAllNotificationTypesAsync();
    Task UpdateNotificationTypeAsync(NotificationType notificationType);
    Task<NotificationType?> GetNotificationTypeByIdAsync(int id);
}
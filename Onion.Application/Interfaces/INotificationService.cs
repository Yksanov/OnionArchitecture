using Onion.Domain.Entities;

namespace Onion.Application.Interfaces;

public interface INotificationService
{
    Task AddNotificationAsync(Notification notification);
    Task RemoveNotificationAsync(Notification notification);
    Task<List<Notification>> GetAllNotificationsAsync();
    Task UpdateNotificationAsync(Notification notification);
    Task<Notification> GetNotificationByIdAsync(int id);
}
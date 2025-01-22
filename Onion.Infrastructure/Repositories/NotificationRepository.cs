using Microsoft.EntityFrameworkCore;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;
using Onion.Infrastructure.Data;

namespace Onion.Infrastructure.Repositories;

public class NotificationRepository : INotificationRepository
{
    private readonly Context _context;

    public NotificationRepository(Context context)
    {
        _context = context;
    }

    public async Task AddNotificationAsync(Notification notification)
    {
        await _context.Notifications.AddAsync(notification);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveNotificationAsync(Notification notification)
    {
        _context.Notifications.Remove(notification);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Notification>> GetAllNotificationsAsync()
    {
        return await _context.Notifications.ToListAsync();
    }

    public async Task UpdateNotificationAsync(Notification notification)
    {
        _context.Notifications.Update(notification);
        await _context.SaveChangesAsync();
    }

    public async Task<Notification> GetNotificationByIdAsync(int id)
    {
        return await _context.Notifications.FirstOrDefaultAsync(n => n.Id == id);
    }
}
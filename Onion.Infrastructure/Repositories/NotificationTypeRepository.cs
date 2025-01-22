using Microsoft.EntityFrameworkCore;
using Onion.Domain.Entities;
using Onion.Domain.Interfaces;
using Onion.Infrastructure.Data;

namespace Onion.Infrastructure.Repositories;

public class NotificationTypeRepository : INotificationTypeRepository
{
    private readonly Context _context;
    
    public NotificationTypeRepository(Context context)
    {
        _context = context;
    }
    
    public async Task AddNotificationTypeAsync(NotificationType notificationType)
    {
        _context.NotificationTypes.Entry(notificationType).State = EntityState.Added;
        await _context.SaveChangesAsync();
    }

    public async Task RemoveNotificationTypeAsync(NotificationType notificationType)
    {
        _context.NotificationTypes.Entry(notificationType).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }

    public async Task<List<NotificationType>> GetAllNotificationTypesAsync()
    {
        return await _context.NotificationTypes.ToListAsync();
    }

    public async Task UpdateNotificationTypeAsync(NotificationType notificationType)
    {
        _context.NotificationTypes.Entry(notificationType).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<NotificationType?> GetNotificationTypeByIdAsync(int id)
    {
        return await _context.NotificationTypes.FirstOrDefaultAsync(b => b.Id == id);
    }
}
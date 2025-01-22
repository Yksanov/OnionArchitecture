namespace Onion.Domain.Entities;

public class Notification
{
    public int Id { get; set; }
    public string Text { get; set; }
    public bool IsRead { get; set; }
    
    public int NotificationTypeId { get; set; }
    public NotificationType? NotificationType { get; set; }
}
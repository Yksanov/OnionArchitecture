using System.ComponentModel.DataAnnotations;

namespace OnionArhitectura.ViewModels;

public class NotificationViewModel
{
    [Required(ErrorMessage = "Текст обязателен к заполнению")]
    public string Text { get; set; }
    [Required(ErrorMessage = "Тип уведомления обязателен к заполнению")]
    public int NotificationTypeId { get; set; }
}
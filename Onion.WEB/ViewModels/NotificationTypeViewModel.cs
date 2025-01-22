using System.ComponentModel.DataAnnotations;

namespace OnionArhitectura.ViewModels;

public class NotificationTypeViewModel
{
    [Required(ErrorMessage = "Поле обязательно к заполнению")]
    public string Name { get; set; }
}
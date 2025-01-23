using System.ComponentModel.DataAnnotations;

namespace OnionArhitectura.ViewModels;

public class LessonNameViewModel
{
    [Required(ErrorMessage = "Поле обязательно к заполнению")]
    public string Name { get; set; }
}
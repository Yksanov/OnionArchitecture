using System.ComponentModel.DataAnnotations;

namespace OnionArhitectura.ViewModels;

public class TeacherViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле обязательно к заполнению")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Поле обязательно к заполнению")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "Поле обязательно к заполнению")]
    public int LessonNameId { get; set; }
    [Required(ErrorMessage = "Поле обязательно к заполнению")]
    public int BranchId { get; set; }
}
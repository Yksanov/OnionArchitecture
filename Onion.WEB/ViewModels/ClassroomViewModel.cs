using System.ComponentModel.DataAnnotations;

namespace OnionArhitectura.ViewModels;

public class ClassroomViewModel
{
    [Required(ErrorMessage = "Поле обязательно к заполнению")]
    public int Capacity { get; set; }
    [Required(ErrorMessage = "Поле обязательно к заполнению")]
    public int BranchId { get; set; }
}
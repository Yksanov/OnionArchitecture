using System.ComponentModel.DataAnnotations;

namespace OnionArhitectura.ViewModels;

public class BranchViewModel
{
    [Required(ErrorMessage = "Поле обязательно к заполнению")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Поле обязательно к заполнению")]
    public string Location { get; set; }
}
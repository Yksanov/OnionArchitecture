using System.ComponentModel.DataAnnotations;

namespace OnionArhitectura.ViewModels;

public class OperationTypeViewModel
{
    [Required(ErrorMessage = "Поле обязательно к заполнению")]
    public string Name { get; set; }
}
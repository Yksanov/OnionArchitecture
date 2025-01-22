using System.ComponentModel.DataAnnotations;

namespace OnionArhitectura.ViewModels;

public class StudentViewModel
{
    [Required(ErrorMessage = "Поле обязательно к заполнению")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Поле обязательно к заполнению")]
    public string LastName {get; set; }
    
    [Required(ErrorMessage = "Поле обязательно к заполнению")]
    public string Phone { get; set; }
    
    [Required(ErrorMessage = "Поле обязательно к заполнению")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "Поле обязательно к заполнению")]
    public int GroupId { get; set; }
}
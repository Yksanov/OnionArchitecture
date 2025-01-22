using System.ComponentModel.DataAnnotations;

namespace OnionArhitectura.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Почта/Логин не могут быть пустым")]
    public string UserNameOrEmail { get; set; }
    [Required(ErrorMessage = "Пароль не может быть пустым")]
    public string Password { get; set; }
    public bool RememberMe { get; set; }
    public string? ReturnUrl { get; set; }
}
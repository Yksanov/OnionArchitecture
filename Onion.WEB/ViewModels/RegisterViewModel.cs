using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace OnionArhitectura.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Роль обязательна к заполнению")]
    public string Role { get; set; }

    [Required(ErrorMessage = "Номер телефона обязательна к заполнению")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Имя обязательна к заполнению")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Фамилия обязательна к заполнению")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Логин обязательна к заполнению")]
    [Remote(action: "CheckUserName", controller: "Validation",
        ErrorMessage = "Пользователь с таким логином уже существует")]
    public string UserName { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Почта в некорректном формате")]
    [Remote(action: "CheckUserEmail", controller: "Validation",
        ErrorMessage = "Пользователь с таким почтой уже существует", AdditionalFields = "Id")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Пароль обязателен к заполнению")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Повтор пароля обязателен к заполнению")]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
}
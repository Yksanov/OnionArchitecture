using System.ComponentModel.DataAnnotations;
using Onion.Domain.Entities;

namespace OnionArhitectura.ViewModels;

public class TrialLessonViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поля обязательно к заполнению")]
    public DateTime Date { get; set; }
    [Required(ErrorMessage = "Поля обязательно к заполнению")]
    public int InvitedCount { get; set; }
    [Required(ErrorMessage = "Поля обязательно к заполнению")]
    public int PassedCount { get; set; }
    [Required(ErrorMessage = "Поля обязательно к заполнению")]
    public int CameCount { get; set; }
    public string? Comment { get; set; }
    
    [Required(ErrorMessage = "Поля обязательно к заполнению")]
    public int TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
}
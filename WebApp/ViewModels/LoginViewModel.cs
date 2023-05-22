using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Du måste ange Email")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "E-Post")]
    public string Email { get; set; } = null!;


    [Required(ErrorMessage = "Du måste ange lösenord")]
    [DataType(DataType.Password)]
    [Display(Name = "Lösenord")]
    public string Password { get; set; } = null!;
}

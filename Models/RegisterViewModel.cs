using System.ComponentModel.DataAnnotations;

namespace tp_todo_list.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Le nom d'utilisateur est requis.")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Le mot de passe est requis.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required(ErrorMessage = "Le confirmation du mot de passe est obligatoire.")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
}
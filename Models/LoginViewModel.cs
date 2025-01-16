using System.ComponentModel.DataAnnotations;

namespace tp_todo_list.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Le nom d'utilisateur est requis.")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Le mot de passe est requis.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}

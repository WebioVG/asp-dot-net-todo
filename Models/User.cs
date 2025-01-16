using Microsoft.AspNetCore.Identity;

namespace tp_todo_list.Models;

public class User : IdentityUser
{
    public String FullName { get; set; }
}
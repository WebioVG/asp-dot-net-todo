using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tp_todo_list.Models;

namespace tp_todo_list;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<Todo> Todos { get; set; }
    public DbSet<User> Users { get; set; }
}
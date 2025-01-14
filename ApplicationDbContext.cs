using Microsoft.EntityFrameworkCore;
using tp_todo_list.Models;

namespace tp_todo_list;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Todo> Todos { get; set; }
}
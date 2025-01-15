using Microsoft.EntityFrameworkCore;

namespace tp_todo_list.Models;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context =
            new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
        
        if (context.Todos.Any())
        {
            return;
        }
            
        context.Todos.AddRange(
            new Todo
            {
                Content = "Allez dans l'espace",
                Status = "terminé"
            },
            new Todo
            {
                Content = "Sauver la planète",
                Status = "en cours"
            },
            new Todo
            {
                Content = "Soigner les maladies incurables",
                Status = "en cours"
            },
            new Todo
            {
                Content = "Empêcher les catastrophes naturelles",
                Status = "en cours"
            },
            new Todo
            {
                Content = "Faire le tour du monde à pieds",
                Status = "terminé"
            }
        );
        context.SaveChanges();
    }
}
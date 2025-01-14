using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tp_todo_list.Models;

public class Todo
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(255)]
    public string Content { get; set; }
    [Required]
    [Column(TypeName = "varchar(20)")]
    public string Status { get; set; }
    
    public Todo() {}
}

public enum TodoStatus
{
    [System.ComponentModel.Description("en cours")]
    EnCours,
    [System.ComponentModel.Description("terminé")]
    Termine
}
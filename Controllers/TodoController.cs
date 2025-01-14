using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tp_todo_list.Models;

namespace tp_todo_list.Controllers;

public class TodoController : Controller
{
    private readonly ApplicationDbContext _context;

    public TodoController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var todos = await _context.Todos.ToListAsync();
        return View(todos);
    }

    [HttpGet]
    public IActionResult Form()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Form(Todo todo)
    {
        if (ModelState.IsValid)
        {
            _context.Add(todo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(todo);
    }
}
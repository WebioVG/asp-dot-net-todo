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
    public async Task<IActionResult> Index(int page = 1, int pageSize = 2)
    {
        var totalItems = await _context.Todos.CountAsync();

        var todos = await _context.Todos
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        ViewBag.CurrentPage = page;
        ViewBag.PageSize = pageSize;
        ViewBag.TotalItems = totalItems;
        ViewBag.TotalPages = (int) Math.Ceiling((double) totalItems / pageSize);

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
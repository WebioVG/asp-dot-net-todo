using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tp_todo_list.Models;
using tp_todo_list.Services;

namespace tp_todo_list.Controllers;

public class TodoController : Controller
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Index(int page = 1, int pageSize = 2)
    {
        var totalItems = await _todoService.GetTotalCount();
        var todos = await _todoService.FindWithPagination(page, pageSize);

        ViewBag.CurrentPage = page;
        ViewBag.PageSize = pageSize;
        ViewBag.TotalItems = totalItems;
        ViewBag.TotalPages = (int) Math.Ceiling((double) totalItems / pageSize);

        return View(todos);
    }

    [HttpGet]
    [Authorize]
    public IActionResult Form()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Form(Todo todo)
    {
        if (ModelState.IsValid)
        {
            await _todoService.CreateTodo(todo);
            return RedirectToAction(nameof(Index));
        }
        return View(todo);
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tp_todo_list.Models;
using tp_todo_list.Repositories;

namespace tp_todo_list.Controllers;

public class TodoController : Controller
{
    private readonly ITodoRepository _todoRepository;

    public TodoController(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Index(int page = 1, int pageSize = 2)
    {
        var totalItems = await _todoRepository.Count();
        var todos = await _todoRepository.FindWithPagination(page, pageSize);

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
            await _todoRepository.Add(todo);
            return RedirectToAction(nameof(Index));
        }
        return View(todo);
    }
}
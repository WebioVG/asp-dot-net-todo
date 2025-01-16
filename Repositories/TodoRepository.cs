using Microsoft.EntityFrameworkCore;
using tp_todo_list.Models;

namespace tp_todo_list.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly ApplicationDbContext _context;

    public TodoRepository(ApplicationDbContext context)
    {
        _context = context;
    }
        
    public async Task<List<Todo>> FindWithPagination(int page, int chunkSize)
    {
        var todos = await _context.Todos
            .Skip((page - 1) * chunkSize)
            .Take(chunkSize)
            .ToListAsync();

        return todos;
    }

    public async Task<int> Count()
    {
        int count = await _context.Todos
            .CountAsync();
        return count;
    }

    public async Task<Todo> Add(Todo todo)
    {
        await _context.AddAsync(todo);
        await _context.SaveChangesAsync();
        return todo;
    }
}
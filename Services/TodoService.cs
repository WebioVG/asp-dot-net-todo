using tp_todo_list.Models;
using tp_todo_list.Repositories;

namespace tp_todo_list.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;

    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }
        
    public async Task<List<Todo>> FindWithPagination(int page, int chunkSize)
    {
        return await _todoRepository.FindWithPagination(page, chunkSize);
    }

    public async Task<int> GetTotalCount()
    {
        return await _todoRepository.Count();
    }

    public async Task<Todo> CreateTodo(Todo todo)
    {
        return await _todoRepository.Add(todo);
    }
}
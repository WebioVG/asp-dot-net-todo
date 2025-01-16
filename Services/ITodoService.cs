using tp_todo_list.Models;

namespace tp_todo_list.Services;

public interface ITodoService
{
    Task<List<Todo>> FindWithPagination(int page, int chunkSize);
    Task<int> GetTotalCount();
    Task<Todo> CreateTodo(Todo todo);
}
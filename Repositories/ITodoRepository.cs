using tp_todo_list.Models;

namespace tp_todo_list.Repositories;

public interface ITodoRepository
{
    Task<List<Todo>> FindWithPagination(int page, int chunkSize);
    Task<int> Count();
    Task<Todo> Add(Todo todo);
}
using API.ToDoList.API.Repositories.Interfaces;
using API.ToDoList.Data;
using API.ToDoList.Shared;
using Microsoft.EntityFrameworkCore;

namespace API.ToDoList.API.Repositories
{
    public class TodoItemRepository : IRepository<TodoItem>
    {
        private readonly APITodoListContext _context;
        public TodoItemRepository(APITodoListContext context) => _context = context;
        public async Task<IEnumerable<TodoItem>> GetAllAsync() => await _context.TodoItems.ToListAsync();
        public async Task<TodoItem> GetByIdAsync(int id) => await _context.TodoItems.FindAsync(id) ?? throw new KeyNotFoundException($"TodoItem with id {id} not found.");
        public async Task AddAsync(TodoItem todoItem)
        {
            await _context.TodoItems.AddAsync(todoItem);
            await SaveAsync();
        }
        public async Task UpdateAsync(TodoItem todoItem)
        {
            _context.TodoItems.Update(todoItem);
            await SaveAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var todoItem = _context.TodoItems.Find(id) ?? throw new KeyNotFoundException($"TodoItem with id {id} not found.");
            _context.TodoItems.Remove(todoItem);
            await SaveAsync();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

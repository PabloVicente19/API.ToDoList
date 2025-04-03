using API.ToDoList.API.Repositories.Interfaces;
using API.ToDoList.Data;
using API.ToDoList.Shared;
using Microsoft.EntityFrameworkCore;

namespace API.ToDoList.API.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly APITodoListContext _context;
        public CategoryRepository(APITodoListContext context) => _context = context;
        public async Task<IEnumerable<Category>> GetAllAsync() => await _context.Categories.ToListAsync();
        public async Task<Category> GetByIdAsync(int id) => await _context.Categories.FindAsync(id) ?? throw new KeyNotFoundException($"Category with id {id} not found.");
        public async Task AddAsync(Category entity)
        {
            await _context.Categories.AddAsync(entity);
            await SaveAsync();
        }
        public async Task UpdateAsync(Category entity)
        {
            _context.Categories.Update(entity);
            await SaveAsync();
        }
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task SaveAsync() => await _context.SaveChangesAsync();

    }
}

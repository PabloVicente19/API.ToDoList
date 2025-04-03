
using API.ToDoList.Shared;
using Microsoft.EntityFrameworkCore;

namespace API.ToDoList.Data
{
    public class APITodoListContext : DbContext
    {
        public APITodoListContext(DbContextOptions<APITodoListContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite();
        }
    }
}

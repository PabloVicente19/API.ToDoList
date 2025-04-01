

namespace API.ToDoList.Shared
{
    public class TodoItem
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}

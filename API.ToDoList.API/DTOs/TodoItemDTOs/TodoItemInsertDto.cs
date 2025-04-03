namespace API.ToDoList.API.DTOs.TodoItemDTOs
{
    public class TodoItemInsertDto
    {
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}

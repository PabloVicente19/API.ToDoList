namespace API.ToDoList.API.DTOs.TodoItemDTOs
{
    public class TodoItemUpdateDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}

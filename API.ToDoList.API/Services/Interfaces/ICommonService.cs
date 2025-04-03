namespace API.ToDoList.API.Services.Interfaces
{
    public interface ICommonService<T, TInsert, TUpdate> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> InsertAsync(TInsert entity);
        Task<T> UpdateAsync(int id, TUpdate entity);
        Task<T> DeleteAsync(int id);
    }
}

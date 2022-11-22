namespace EfWebTutorial.Interfaces
{

    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAllItemsAsync();
        Task<List<T>> GetAllItemsSortedAsync();
        Task<T> GetOneItemAsync(int id); 
        Task CreateAsync(T item); 
        Task <bool> DeleteAsync(int? id); 
        Task EditAsync(T item);
    }
}

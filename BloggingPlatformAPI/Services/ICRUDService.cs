namespace BloggingPlatformAPI.Services
{
    public interface ICRUDService<T, TI, TU>
    {
        List<string> Errors { get; set; }
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int Id);
        Task<T> Insert(TI Insert);
        Task<T> Update(int Id,TU Update);
        IEnumerable<T> FilterByCategory(string filter);
        Task<T> Delete(int id);
    }
}

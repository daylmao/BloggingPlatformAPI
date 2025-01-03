namespace BlogginPlatformApi.Core.Application.Interfaces.Services
{
    public interface IBaseCRUDService<T, TI, TU>
    {
        List<string> Errors { get; set; }
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int Id);
        Task<T> InsertAsync(TI Insert);
        Task<T> UpdateAsync(int Id, TU Update);
        Task<T> DeleteAsync(int id);
    }
}

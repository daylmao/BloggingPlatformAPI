namespace BloggingPlatformAPI.Repository
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int Id);
        Task Insert(TEntity Insert);
        Task Update(TEntity Update);
        IEnumerable<TEntity> FilterByCategory(string categoryName);
        Task Delete(TEntity entity);
        Task SaveChangesAsync();
    }
}

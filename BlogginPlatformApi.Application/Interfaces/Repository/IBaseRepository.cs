using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogginPlatformAPI.Core.Application.Interfaces.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int Id);
        Task InsertAsync(TEntity Insert);
        Task UpdateAsync(TEntity Update);
        Task DeleteAsync(TEntity entity);
        Task SaveChangesAsync();
    }
}

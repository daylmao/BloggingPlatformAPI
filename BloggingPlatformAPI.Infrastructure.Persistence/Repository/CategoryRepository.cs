using BloggingPlatformAPI.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using BloggingPlatformAPI.Entities;
using BlogginPlatformAPI.Core.Application.Interfaces.Repository;

namespace BloggingPlatformAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BlogContext _blogContext;

        public CategoryRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<IEnumerable<Category>> GetAllAsync() => await _blogContext.Set<Category>().ToListAsync();


        public async Task<Category> GetByIdAsync(int Id) => await _blogContext.Categories.FindAsync(Id);

        public async Task InsertAsync(Category Insert)
        {
            await _blogContext.Categories.AddAsync(Insert);
            await SaveChangesAsync();
        }
        public async Task UpdateAsync(Category Update)
        {
            _blogContext.Categories.Attach(Update);
            _blogContext.Entry(Update).State = EntityState.Modified;
            await SaveChangesAsync();
        }
        public async Task DeleteAsync(Category entity)
        {
            _blogContext.Categories.Remove(entity);
            await SaveChangesAsync();
        }

        public IEnumerable<Category> FilterByCategoryAsync(string categoryName)
        {
            return _blogContext.Categories
                      .Where(c => c.Name == categoryName && c.Blogs.Any())
                      .ToList();
        }
        
        public async Task SaveChangesAsync() => await _blogContext.SaveChangesAsync();

    }
}

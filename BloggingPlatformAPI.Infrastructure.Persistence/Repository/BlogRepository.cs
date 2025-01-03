
using BloggingPlatformAPI.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using BloggingPlatformAPI.Entities;
using BlogginPlatformAPI.Core.Application.Interfaces.Repository;


namespace BloggingPlatformAPI.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogContext _blogContext;

        public BlogRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<IEnumerable<Blog>> GetAllAsync() => await _blogContext.Blogs.ToListAsync();
        public async Task<Blog> GetByIdAsync(int Id) => await _blogContext.Blogs.FindAsync(Id);

        public async Task InsertAsync(Blog Insert)
        {
            await _blogContext.Blogs.AddAsync(Insert);
            await SaveChangesAsync();
        }
        public async Task UpdateAsync(Blog Update)
        {
            _blogContext.Attach(Update);
            _blogContext.Entry(Update).State = EntityState.Modified;
            await SaveChangesAsync();
        }
        public IEnumerable<Blog> FilterByCategoryAsync(string categoryName)
        {
            return _blogContext.Blogs.Where(b => b.Category.Name == categoryName).ToList();
        }
        public async Task DeleteAsync(Blog entity)
        {
            _blogContext.Blogs.Remove(entity);
            await SaveChangesAsync();
        }
        public async Task SaveChangesAsync() => await _blogContext.SaveChangesAsync();
       

    }
}

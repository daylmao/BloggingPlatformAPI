using BloggingPlatformAPI.DTOs;
using BloggingPlatformAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformAPI.Repository
{
    public class BlogRepository : IRepository<Blog>
    {
        private readonly BlogContext _blogContext;

        public BlogRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<IEnumerable<Blog>> GetAll() => await _blogContext.Blogs.ToListAsync();
        public async Task<Blog> GetById(int Id) => await _blogContext.Blogs.FindAsync(Id);

        public async Task Insert(Blog Insert)
        {
            await _blogContext.Blogs.AddAsync(Insert);
            await SaveChangesAsync();
        }
        public async Task Update(Blog Update)
        {
            _blogContext.Attach(Update);
            _blogContext.Entry(Update).State = EntityState.Modified;
            await SaveChangesAsync();
        }
        public IEnumerable<Blog> FilterByCategory(string categoryName)
        {
            return _blogContext.Blogs.Where(b => b.Category.Name == categoryName).ToList();
        }
        public async Task Delete(Blog entity)
        {
            _blogContext.Blogs.Remove(entity);
            await SaveChangesAsync();
        }
        public async Task SaveChangesAsync() => await _blogContext.SaveChangesAsync();
       

    }
}

using BloggingPlatformAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace BloggingPlatformAPI.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly BlogContext _blogContext;

        public CategoryRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<IEnumerable<Category>> GetAll() => await _blogContext.Categories.ToListAsync();

        public async Task<Category> GetById(int Id) => await _blogContext.Categories.FindAsync(Id);

        public async Task Insert(Category Insert)
        {
            await _blogContext.Categories.AddAsync(Insert);
            await SaveChangesAsync();
        }
        public async Task Update(Category Update)
        {
            _blogContext.Categories.Attach(Update);
            _blogContext.Entry(Update).State = EntityState.Modified;
            await SaveChangesAsync();
        }
        public async Task Delete(Category entity)
        {
            _blogContext.Categories.Remove(entity);
            await SaveChangesAsync();
        }

        public IEnumerable<Category> FilterByCategory(string categoryName)
        {
            return _blogContext.Categories
                      .Where(c => c.Name == categoryName && c.Blogs.Any())
                      .ToList();
        }
        

        public async Task SaveChangesAsync() => await _blogContext.SaveChangesAsync();

    }
}

using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformAPI.Models
{
    public class BlogContext: DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options){}

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region BlogCategory
            modelBuilder.Entity<Blog>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Blogs)
                .HasForeignKey(b => b.CategoryId);
            #endregion

        }
    }
}

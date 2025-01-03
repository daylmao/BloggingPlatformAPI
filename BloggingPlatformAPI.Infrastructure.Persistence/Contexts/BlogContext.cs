using Microsoft.EntityFrameworkCore;
using BloggingPlatformAPI.Entities;

namespace BloggingPlatformAPI.Infrastructure.Persistence.Contexts
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Primary Key
            modelBuilder.Entity<Blog>()
                .HasKey(b => b.BlogId)
                .HasName("PKBlog");

            modelBuilder.Entity<Category>()
                .HasKey(b => b.CategoryId)
                .HasName("PKCategory");
            #endregion


            #region BlogCategory
            modelBuilder.Entity<Blog>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Blogs)
                .HasForeignKey(b => b.CategoryId)
                .HasConstraintName("fkCategory");
            #endregion

        }
    }
}

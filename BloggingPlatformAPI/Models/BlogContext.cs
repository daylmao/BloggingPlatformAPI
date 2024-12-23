using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformAPI.Models
{
    public class BlogContext: DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region BlogCategory
            modelBuilder.Entity<Blog>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Blogs)
                .HasForeignKey(b => b.CategoryId);
            #endregion

            #region BlogsTags
            modelBuilder.Entity<Blog>()
                .HasMany(b => b.Tags)
                .WithMany(t => t.Blogs)
                .UsingEntity(n => n.ToTable("BlogsTags"));
            #endregion
        }
    }
}

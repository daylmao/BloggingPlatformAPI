using BloggingPlatformAPI.Infrastructure.Persistence.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BloggingPlatformAPI.Repository;
using BloggingPlatformAPI.Entities;

namespace BloggingPlatformAPI.Infrastructure.Persistence
{
    public static class AddInfrastructure
    {
        public static void AddPersistence(this IServiceCollection Services, IConfiguration configuration  )
        {
            #region connection
            // Entity Framework
          
            Services.AddDbContext<BlogContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BlogConnection"),
                    b => b.MigrationsAssembly(typeof(BlogContext).Assembly.FullName)));

            #endregion


            #region repository
            Services.AddTransient<IRepository<Blog>, BlogRepository>();
            Services.AddTransient<IRepository<Category>, CategoryRepository>();
            #endregion
        }
    }
}

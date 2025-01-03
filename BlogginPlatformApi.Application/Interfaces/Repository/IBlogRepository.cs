using BloggingPlatformAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogginPlatformAPI.Core.Application.Interfaces.Repository
{
    public interface IBlogRepository:IBaseRepository<Blog>
    {
        IEnumerable<Blog> FilterByCategoryAsync(string categoryName);
    }
}

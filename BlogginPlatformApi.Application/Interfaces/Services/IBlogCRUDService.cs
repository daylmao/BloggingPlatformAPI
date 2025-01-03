using BloggingPlatformAPI.DTOs;
using BlogginPlatformApi.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogginPlatformAPI.Core.Application.Interfaces.Services
{
    public interface IBlogCRUDService:IBaseCRUDService<BlogDTO,BlogInsertDTO,BlogUpdateDTO>
    {
        IEnumerable<BlogDTO> FilterByCategoryAsync(string filter);
    }
}

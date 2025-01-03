using BloggingPlatformAPI.DTOs;
using BlogginPlatformApi.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogginPlatformAPI.Core.Application.Interfaces.Services
{
    public interface ICategoryCRUDService:IBaseCRUDService<CategoryDTO,CategoryInsertDTO,CategoryUpdateDTO>
    {
    }
}

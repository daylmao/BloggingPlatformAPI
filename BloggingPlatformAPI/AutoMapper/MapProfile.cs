using AutoMapper;
using BloggingPlatformAPI.DTOs;
using BloggingPlatformAPI.Models;

namespace BloggingPlatformAPI.AutoMapper
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            #region blog
            CreateMap<Blog,BlogDTO>().ReverseMap();
            CreateMap<BlogInsertDTO, Blog>();
            CreateMap<BlogUpdateDTO, Blog>();
            #endregion

            #region category
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<CategoryInsertDTO, Category>();
            CreateMap<CategoryUpdateDTO, Category>();
            #endregion
        }
    }
}

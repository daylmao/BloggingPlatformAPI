using BloggingPlatformAPI.AutoMapper;
using BloggingPlatformAPI.DTOs;
using BloggingPlatformAPI.Services;
using BloggingPlatformAPI.Validators;
using BlogginPlatformApi.Core.Application.Interfaces.Services;
using BlogginPlatformAPI.Core.Application.Interfaces.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BlogginPlatformAPI.Core.Application
{
    public static class AddApplication
    {
        public static void AddServices(this IServiceCollection Services)
        {
            #region automapper
            Services.AddAutoMapper(typeof(MapProfile));
            #endregion

            #region services
            Services.AddScoped<IBlogCRUDService, BlogService>();
            Services.AddScoped<ICategoryCRUDService, CategoryService>();
            #endregion

            #region validators
            Services.AddValidatorsFromAssemblyContaining<BlogInsertValidator>();
            Services.AddValidatorsFromAssemblyContaining<BlogUpdateValidator>();
            Services.AddValidatorsFromAssemblyContaining<CategoryInsertValidator>();
            Services.AddValidatorsFromAssemblyContaining<CategoryUpdateValidator>();
            #endregion
        }
    }
}

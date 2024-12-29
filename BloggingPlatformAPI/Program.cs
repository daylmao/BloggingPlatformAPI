using BloggingPlatformAPI.AutoMapper;
using BloggingPlatformAPI.DTOs;
using BloggingPlatformAPI.Models;
using BloggingPlatformAPI.Repository;
using BloggingPlatformAPI.Services;
using BloggingPlatformAPI.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICRUDService<BlogDTO, BlogInsertDTO, BlogUpdateDTO>, BlogService>();
builder.Services.AddScoped<ICRUDService<CategoryDTO, CategoryInsertDTO, CategoryUpdateDTO>, CategoryService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Validators
builder.Services.AddValidatorsFromAssemblyContaining<BlogInsertValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<BlogUpdateValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CategoryInsertValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CategoryUpdateValidator>();


// Repository
builder.Services.AddScoped<IRepository<Blog>, BlogRepository>();
builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();

// Entity Framework
builder.Services.AddDbContext<BlogContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BlogConnection")));

// automapper
builder.Services.AddAutoMapper(typeof(MapProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

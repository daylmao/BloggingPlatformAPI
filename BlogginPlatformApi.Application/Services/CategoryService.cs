using AutoMapper;
using BloggingPlatformAPI.DTOs;
using BloggingPlatformAPI.Entities;
using BlogginPlatformApi.Core.Application.Interfaces.Services;
using BlogginPlatformAPI.Core.Application.Interfaces.Repository;
using BlogginPlatformAPI.Core.Application.Interfaces.Services;

namespace BloggingPlatformAPI.Services
{
    public class CategoryService : ICategoryCRUDService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public List<string> Errors { get; set; }
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            Errors = new List<string>();
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var info = await _categoryRepository.GetAllAsync();
            return info.Select(b => _mapper.Map<CategoryDTO>(b));   
        }

        public async Task<CategoryDTO> GetByIdAsync(int Id)
        {
            var info = await _categoryRepository.GetByIdAsync(Id);
            if (info == null)
            {
                return null;
            }
            return _mapper.Map<CategoryDTO>(info);
        }

        public async Task<CategoryDTO> InsertAsync(CategoryInsertDTO Insert)
        {
            var insert = _mapper.Map<Category>(Insert);
            await _categoryRepository.InsertAsync(insert);
            return _mapper.Map<CategoryDTO>(insert);
            
        }

        public async Task<CategoryDTO> UpdateAsync(int Id, CategoryUpdateDTO Update)
        {
            var oldData = await _categoryRepository.GetByIdAsync(Id);
            if (oldData == null)
            {
                return null;
            }
            var update = _mapper.Map(Update, oldData);
            await _categoryRepository.UpdateAsync(update);
            return _mapper.Map<CategoryDTO>(update);
        }

        public async Task<CategoryDTO> DeleteAsync(int Id)
        {
            var info = await _categoryRepository.GetByIdAsync(Id);
            await _categoryRepository.DeleteAsync(info);
            return _mapper.Map<CategoryDTO>(info);
        }
    }
}

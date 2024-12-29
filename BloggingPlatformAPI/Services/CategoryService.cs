using AutoMapper;
using BloggingPlatformAPI.DTOs;
using BloggingPlatformAPI.Models;
using BloggingPlatformAPI.Repository;

namespace BloggingPlatformAPI.Services
{
    public class CategoryService : ICRUDService<CategoryDTO, CategoryInsertDTO, CategoryUpdateDTO>
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public List<string> Errors { get; set; }
        public CategoryService(IRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            Errors = new List<string>();
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            var info = await _categoryRepository.GetAll();
            return info.Select(b => _mapper.Map<CategoryDTO>(b));   
        }

        public async Task<CategoryDTO> GetById(int Id)
        {
            var info = await _categoryRepository.GetById(Id);
            if (info == null)
            {
                return null;
            }
            return _mapper.Map<CategoryDTO>(info);
        }

        public async Task<CategoryDTO> Insert(CategoryInsertDTO Insert)
        {
            var insert = _mapper.Map<Category>(Insert);
            await _categoryRepository.Insert(insert);
            return _mapper.Map<CategoryDTO>(insert);
            
        }

        public async Task<CategoryDTO> Update(int Id, CategoryUpdateDTO Update)
        {
            var oldData = await _categoryRepository.GetById(Id);
            if (oldData == null)
            {
                return null;
            }
            var update = _mapper.Map(Update, oldData);
            await _categoryRepository.Update(update);
            return _mapper.Map<CategoryDTO>(update);
        }
        public IEnumerable<CategoryDTO> FilterByTag(string filter)
        {
            var filtered = _categoryRepository.FilterByTag(b => b.Name == filter).ToList();
            if (filtered == null || !filtered.Any())
            {
                Errors.Add("There is no a category with that name");
                return Enumerable.Empty<CategoryDTO>();
            }
            return filtered.Select(b => _mapper.Map<CategoryDTO>(b)); ;
        }
        public async Task<CategoryDTO> Delete(int Id)
        {
            var info = await _categoryRepository.GetById(Id);
            await _categoryRepository.Delete(info);
            return _mapper.Map<CategoryDTO>(info);
        }
    }
}

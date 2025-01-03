using AutoMapper;
using BloggingPlatformAPI.DTOs;
using BloggingPlatformAPI.Entities;
using BlogginPlatformAPI.Core.Application.Interfaces.Repository;
using BlogginPlatformAPI.Core.Application.Interfaces.Services;

namespace BloggingPlatformAPI.Services
{
    public class BlogService : IBlogCRUDService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapProfile;

        public List<string> Errors { get; set; }
        public BlogService(IBlogRepository blogRepository, IMapper mapProfile)
        {
            _blogRepository = blogRepository;
            _mapProfile = mapProfile;
            Errors = new List<string>();
        }

        public async Task<IEnumerable<BlogDTO>> GetAllAsync()
        {
            var info = await _blogRepository.GetAllAsync();
            return info.Select(b => _mapProfile.Map<BlogDTO>(b));
        }

        public async Task<BlogDTO> GetByIdAsync(int Id)
        {
            var info = await _blogRepository.GetByIdAsync(Id);
            if (info == null)
            {
                return null;
            }
            return _mapProfile.Map<BlogDTO>(info);

        }

        public async Task<BlogDTO> InsertAsync(BlogInsertDTO Insert)
        {
            var insert = _mapProfile.Map<Blog>(Insert);
            await _blogRepository.InsertAsync(insert);
            return _mapProfile.Map<BlogDTO>(insert);
        }

        public async Task<BlogDTO> UpdateAsync(int Id, BlogUpdateDTO Update)
        {
            var oldData = await _blogRepository.GetByIdAsync(Id);
            if (oldData == null)
            {
                return null;
            }
            var newInfo = _mapProfile.Map(Update, oldData);
            newInfo.UpdatedAt = DateTime.Now;
            await _blogRepository.UpdateAsync(newInfo);
            return _mapProfile.Map<BlogDTO>(newInfo);
        }

        public IEnumerable<BlogDTO> FilterByCategoryAsync(string filter)
        {
            var filtered =  _blogRepository.FilterByCategoryAsync(filter);
            if (filtered == null || !filtered.Any())
            {
                Errors.Add("There is no category with that name");
                return null;
            }
            return filtered.Select(b => _mapProfile.Map<BlogDTO>(b));
        }

        public async Task<BlogDTO> DeleteAsync(int Id)
        {
            var info = await _blogRepository.GetByIdAsync(Id);
            if (info == null)
            {
                return null;
            }
            await _blogRepository.DeleteAsync(info);
            return _mapProfile.Map<BlogDTO>(info);
        }
    }
}

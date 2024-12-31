using AutoMapper;
using BloggingPlatformAPI.DTOs;
using BloggingPlatformAPI.Entities;
using BloggingPlatformAPI.Repository;
using BlogginPlatformApi.Core.Application.Interfaces.Services;

namespace BloggingPlatformAPI.Services
{
    public class BlogService : ICRUDService<BlogDTO, BlogInsertDTO, BlogUpdateDTO>
    {
        private readonly IRepository<Blog> _blogRepository;
        private readonly IMapper _mapProfile;

        public List<string> Errors { get; set; }
        public BlogService(IRepository<Blog> blogRepository, IMapper mapProfile)
        {
            _blogRepository = blogRepository;
            _mapProfile = mapProfile;
            Errors = new List<string>();
        }

        public async Task<IEnumerable<BlogDTO>> GetAll()
        {
            var info = await _blogRepository.GetAll();
            return info.Select(b => _mapProfile.Map<BlogDTO>(b));
        }

        public async Task<BlogDTO> GetById(int Id)
        {
            var info = await _blogRepository.GetById(Id);
            if (info == null)
            {
                return null;
            }
            return _mapProfile.Map<BlogDTO>(info);

        }

        public async Task<BlogDTO> Insert(BlogInsertDTO Insert)
        {
            var insert = _mapProfile.Map<Blog>(Insert);
            await _blogRepository.Insert(insert);
            return _mapProfile.Map<BlogDTO>(insert);
        }

        public async Task<BlogDTO> Update(int Id, BlogUpdateDTO Update)
        {
            var oldData = await _blogRepository.GetById(Id);
            if (oldData == null)
            {
                return null;
            }
            var newInfo = _mapProfile.Map(Update, oldData);
            newInfo.UpdatedAt = DateTime.Now;
            await _blogRepository.Update(newInfo);
            return _mapProfile.Map<BlogDTO>(newInfo);
        }

        public IEnumerable<BlogDTO> FilterByCategory(string filter)
        {
            var filtered =  _blogRepository.FilterByCategory(filter);
            if (filtered == null || !filtered.Any())
            {
                Errors.Add("There is no category with that name");
                return null;
            }
            return filtered.Select(b => _mapProfile.Map<BlogDTO>(b));
        }

        public async Task<BlogDTO> Delete(int Id)
        {
            var info = await _blogRepository.GetById(Id);
            if (info == null)
            {
                return null;
            }
            await _blogRepository.Delete(info);
            return _mapProfile.Map<BlogDTO>(info);
        }
    }
}

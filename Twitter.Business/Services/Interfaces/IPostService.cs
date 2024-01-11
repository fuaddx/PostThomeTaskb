using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.Dtos.PostDtos;
using Twitter.Business.Dtos.TopicDtos;

namespace Twitter.Business.Services.Interfaces
{
    public interface IPostService
    {
        public IEnumerable<PostListItemDto> GetAll();
        public Task<PostListItemDto> GetByIdAsync(int id);
        Task Create(PostCreateDto dto,string authorname);
        public Task RemoveAsync(int id);
        public Task UpdateAsync(int id, PostUpdateDto dto);
        public Task DeleteAsync(int id);
    }
}

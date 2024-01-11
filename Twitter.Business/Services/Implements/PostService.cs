using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.Dtos.PostDtos;
using Twitter.Business.Dtos.TopicDtos;
using Twitter.Business.Exceptions.Common;
using Twitter.Business.Repositories.Interfaces;
using Twitter.Business.Services.Interfaces;
using Twitter.Core.Entities;
using Twitter.Core.Entity;

namespace Twitter.Business.Services.Implements
{
    public class PostService:IPostService
    {
        IPostRepository _repo { get; }
        IMapper _mapper { get; }
        IHttpContextAccessor _contextAccessor { get; }
        UserManager<AppUser> _userManager {  get; }
        readonly string userId;
        public PostService(IPostRepository repo, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager, IMapper mapper)
        {
            _repo = repo;
            _contextAccessor = contextAccessor;

            userId = _contextAccessor.HttpContext?.User.Claims. 
             First(x => x.Type == ClaimTypes.NameIdentifier).Value ?? throw new NullReferenceException();


            _userManager = userManager;
            _mapper = mapper;
        }

        public IEnumerable<PostListItemDto> GetAll()
       => _mapper.Map<IEnumerable<PostListItemDto>>(_repo.GetAll());
        public async Task<PostListItemDto> GetByIdAsync(int id)
        {
            var data = await _checkId(id, true);
            return _mapper.Map<PostListItemDto>(data);
        }
        public async Task Create(PostCreateDto dto, string authorName)
        {
            var post = new Post
            {
                AppUserId = userId,
                Content = dto.Content,
                AuthorName = authorName,
            };

            await _repo.CreateAsync(post);
            await _repo.SaveAsync();
            var createdPost = await _repo.GetPostWithUserAsync(post.Id);
        }
        
        async Task<Post> _checkId(int id, bool isTrack = false)
        {
            if (id <= 0) throw new ArgumentException();
            var data = await _repo.GetByIdAsync(id, isTrack);
            if (data == null) throw new NotFoundException<Topic>();
            return data;
        }
       
        public async Task UpdateAsync(int id, PostUpdateDto dto)
        {
            if (id <= 0) throw new ArgumentException();
            if (dto.Content.ToLower() != dto.Content.ToLower())
            {
                if (await _repo.IsExistAsync(r => r.Content.ToLower() == dto.Content.ToLower()))
                    await _repo.SaveAsync();
            }
        }
         public async Task RemoveAsync(int id)
        {
            var data = await _checkId(id);
            _repo.Remove(data);
            await _repo.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _checkId(id);
            if(data== null) throw new NotFoundException<Topic>();
             _repo.Delete(data); 
            await _repo.SaveAsync();
        }

       
    }
}

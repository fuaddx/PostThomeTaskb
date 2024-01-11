using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.Dtos.PostDtos;
using Twitter.Business.Dtos.TopicDtos;
using Twitter.Core.Entities;
using Twitter.Core.Entity;


namespace Twitter.Business.Profiles
{
    public class PostMappingProfile:Profile
    {
        public PostMappingProfile()
        {
            CreateMap<PostCreateDto, Post>();
            CreateMap<PostUpdateDto, Post>();
            CreateMap<Post, PostListItemDto>();
        }
    }
}

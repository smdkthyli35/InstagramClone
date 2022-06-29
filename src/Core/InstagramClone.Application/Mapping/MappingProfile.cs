using AutoMapper;
using InstagramClone.Application.Features.Commands.Post.CreatePost;
using InstagramClone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, CreatePostCommandRequest>()
               .ReverseMap();

            //CreateMap<Post, DeletePostCommandRequest>()
            //   .ReverseMap();

            //CreateMap<Post, UpdatePostCommandRequest>()
            //   .ReverseMap();
        }
    }
}

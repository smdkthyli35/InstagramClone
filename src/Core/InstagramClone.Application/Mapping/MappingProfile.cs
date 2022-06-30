using AutoMapper;
using InstagramClone.Application.Features.Commands.Post.CreatePost;
using InstagramClone.Application.Features.Commands.Post.UpdatePost;
using InstagramClone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profile = AutoMapper.Profile;

namespace InstagramClone.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, CreatePostCommandRequest>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ReverseMap();

            CreateMap<Post, UpdatePostCommandRequest>()
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(x => DateTime.Now))
               .ReverseMap();
        }
    }
}

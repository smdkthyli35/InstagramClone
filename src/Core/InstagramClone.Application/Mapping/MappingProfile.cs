using AutoMapper;
using InstagramClone.Application.Features.Commands.Like.CreateLike;
using InstagramClone.Application.Features.Commands.Post.CreatePost;
using InstagramClone.Application.Features.Commands.Post.UpdatePost;
using InstagramClone.Application.Features.Commands.Reply.CreateReply;
using InstagramClone.Application.Features.Commands.Reply.UpdateReply;
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

            CreateMap<Like, CreateLikeCommandRequest>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ReverseMap();

            CreateMap<Reply, CreateReplyCommandRequest>()
               .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
               .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(x => DateTime.Now))
               .ReverseMap();


            CreateMap<Reply, UpdateReplyCommandRequest>()
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ReverseMap();
        }
    }
}

using AutoMapper;
using BarisTutakli.Blog.Application.Models.PostModels;
using BarisTutakli.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Application.Tools.MappingProfiles
{
    public class PostMappingProfile:Profile
    {
        public PostMappingProfile()
        {
            CreateMap<CreatePostModel, Post>().ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Parse(DateTime.Now.ToShortDateString())));
            CreateMap<Post, GetPostModel>().ForMember(dest=>dest.Tags,opt=>opt.MapFrom(src=>src.Tags));
            CreateMap<Post, GetPostModel>().ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories));
        }
    }
}

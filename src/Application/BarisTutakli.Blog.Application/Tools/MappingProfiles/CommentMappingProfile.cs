using AutoMapper;
using BarisTutakli.Blog.Application.Models.CommentModels;
using BarisTutakli.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Application.Tools.MappingProfiles
{
    public class CommentMappingProfile:Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<CreateCommentModel, Comment>().ForMember(dest=>dest.CreatedAt,opt=>opt.MapFrom(src=>DateTime.Parse(DateTime.Now.ToShortDateString())));
            CreateMap<Comment, GetCommentModel>().ForMember(dest=>dest.Post,opt=>opt.MapFrom(src=>src.Post))
                .ForPath(dest=>dest.Post,opt=>opt.MapFrom(src=>src.Post));
        }
    }
}

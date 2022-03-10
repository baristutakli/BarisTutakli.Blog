using AutoMapper;
using BarisTutakli.Blog.Application.Models.CategoryModels;
using BarisTutakli.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Application.Tools.MappingProfiles
{
    public class CategoryMappingProfile:Profile
    {
        public CategoryMappingProfile()
        {

            CreateMap<CreateCategoryModel, Category>().ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Parse(DateTime.Now.ToShortDateString())));

            CreateMap<Category, GetCategoryTitleModel>().ReverseMap();
            CreateMap<Category, GetCategoryModel>()
               .ForMember(dest => dest.Posts, opt => opt.MapFrom(src => src.Posts)).ReverseMap();
     
        }
    }
}


using BarisTutakli.Blog.Application.Dto;
using BarisTutakli.Blog.Application.Models.CategoryModels;
using BarisTutakli.Blog.Application.Wrappers;
using BarisTutakli.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces
{
    public interface ICategoryService
    {
        Response<List<GetCategoryModel>> GetAll(Expression<Func<Category, bool>> filter = null);
        Response<GetCategoryModel> Get(Expression<Func<Category, bool>> filter);
        Response<List<GetCategoryTitleModel>> GetTitles(Expression<Func<Category, bool>> filter = null);
        Response Add(CreateCategoryModel createCategoryModel);
        Response Update(int id, UpdateCategoryModel updateCategoryModel);
        Response Delete(DeleteCategoryModel deleteCategoryModel);
    }
}

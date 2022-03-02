
using BarisTutakli.Blog.Application.Dto;
using BarisTutakli.Blog.Application.Models.CategoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces
{
    public interface ICategoryService
    {
        List<GetCategoryModel> GetAll(Expression<Func<CategoryDto, bool>> filter = null);
        GetCategoryTitleModel Get(Expression<Func<CategoryDto, bool>> filter);
        bool Add(CreateCategoryModel createCategoryModel);
        bool Update(int id, UpdateCategoryModel updateCategoryModel);
        bool Delete(DeleteCategoryModel deleteCategoryModel);
    }
}

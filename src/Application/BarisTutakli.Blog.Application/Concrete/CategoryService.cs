using AutoMapper;
using BarisTutakli.Blog.Application.Dto;
using BarisTutakli.Blog.Application.Models.CategoryModels;
using BarisTutakli.Blog.Application.Wrappers;
using BarisTutakli.Blog.Domain.Entities;
using BarisTutakli.Blog.DomainServices.Interfaces;
using Blog.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.Application.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Response Add(CreateCategoryModel createCategoryModel)
        {
            var category = _mapper.Map<Category>(createCategoryModel);
            _unitOfWork.Categories.Add(category);
            var result = _unitOfWork.Complete();
            return result > 0 ? new Response() { Status = "Success" } : new Response() { Status = "Failed" };
        }


        public Response Delete(DeleteCategoryModel deleteCategoryModel)
        {
            var category = _unitOfWork.Categories.GetById(deleteCategoryModel.Id).Result;
            _unitOfWork.Categories.Delete(category);
            var result = _unitOfWork.Complete();
            return result > 0 ? new Response() { Status = "Success" } : new Response() { Status = "Failed" };
        }


        public Response<GetCategoryModel> Get(Expression<Func<Category, bool>> filter)
        {
            
            var category = _unitOfWork.Categories.Get(filter).Result;
             var categoryModel = _mapper.Map<GetCategoryModel>(category);
            Response<GetCategoryModel> response = new Response<GetCategoryModel>();
            response.Data = categoryModel;
            response.Succeeded = true;
            return response;
        }

        public Response<List<GetCategoryTitleModel>> GetTitles(Expression<Func<Category, bool>> filter=null)
        {

            var category = _unitOfWork.Categories.GetTitles(filter).Result;
            var categoryModel = _mapper.Map<List<GetCategoryTitleModel>>(category);
            Response<List<GetCategoryTitleModel>> response = new Response<List<GetCategoryTitleModel>>();
            response.Data = categoryModel;
            response.Succeeded = true;
            return response;
        }

        public Response<List<GetCategoryModel>> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            var category = _unitOfWork.Categories.GetAll(filter).Result;
            var categoryModel = _mapper.Map<List<GetCategoryModel>>(category);
            Response<List<GetCategoryModel>> response = new Response<List<GetCategoryModel>>();
            response.Data = categoryModel;
            response.Succeeded = true;
            return response;
        }

        public Response Update(int id, UpdateCategoryModel updateCategoryModel)
        {
            var category = _unitOfWork.Categories.GetById(id).Result;
            updateCategoryModel.Id = id;
            _unitOfWork.Categories.Delete(category);
            var result = _unitOfWork.Complete();
            return result > 0 ? new Response() { Status = "Success" } : new Response() { Status = "Failed" };
        }

    }
}

using AutoMapper;
using BarisTutakli.Blog.Application.Models.TagModels;
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
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TagService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Response Add(CreateTagModel createTagModel)
        {
            var tag = _mapper.Map<Tag>(createTagModel);
            _unitOfWork.Tags.Add(tag);
            var result = _unitOfWork.Complete();
            return result > 0 ? new Response() { Status = "Success" } : new Response() { Status = "Failed" };
        }

        public Response Delete(DeleteTagModel deleteTagModel)
        {
            var tag = _unitOfWork.Tags.GetById(deleteTagModel.Id).Result;
            _unitOfWork.Tags.Delete(tag);
            var result = _unitOfWork.Complete();
            return result > 0 ? new Response() { Status = "Success" } : new Response() { Status = "Failed" };
        }

        public Response<GetTagModel> Get(Expression<Func<Tag, bool>> filter)
        {
            var tag = _unitOfWork.Tags.Get(filter).Result;
            var tagModel = _mapper.Map<GetTagModel>(tag);
            Response<GetTagModel> response = new Response<GetTagModel>();
            response.Data = tagModel ;
            response.Succeeded = true;
            return response;
        }


        public Response<List<GetTagModel>> GetAll(Expression<Func<Tag, bool>> filter = null)
        {
            var tag = _unitOfWork.Tags.GetAll(filter).Result;
            var tagModel = _mapper.Map<List<GetTagModel>>(tag);
            Response<List<GetTagModel>> response = new Response<List<GetTagModel>>();
            response.Data = tagModel ;
            response.Succeeded = true;
            return response;
        }

        public Response Update(int id, UpdateTagModel updateTagModel)
        {
            var tag = _unitOfWork.Tags.GetById(id).Result;
            updateTagModel.Id = id;
            _unitOfWork.Tags.Delete(tag);
            var result = _unitOfWork.Complete();
           return result > 0 ? new Response() { Status = "Success" } : new Response() { Status = "Failed" };
        }
    }
}

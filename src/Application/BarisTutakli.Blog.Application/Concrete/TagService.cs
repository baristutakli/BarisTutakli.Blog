using AutoMapper;
using BarisTutakli.Blog.Application.Models.TagModels;
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
        public bool Add(CreateTagModel createTagModel)
        {
            var tag = _mapper.Map<Tag>(createTagModel);
            _unitOfWork.Tags.Add(tag);
            var result = _unitOfWork.Complete();
            return result > 0 ? true : false; ;
        }

        public bool Delete(DeleteTagModel deleteTagModel)
        {
            var tag = _unitOfWork.Tags.GetById(deleteTagModel.Id).Result;
            _unitOfWork.Tags.Delete(tag);
            var result = _unitOfWork.Complete();
            return result > 0 ? true : false;
        }

        public GetTagModel Get(Expression<Func<Tag, bool>> filter)
        {
            var tag = _unitOfWork.Tags.Get(filter).Result;
            var tagModel = _mapper.Map<GetTagModel>(tag);
            return tagModel;
        }


        public List<GetTagModel> GetAll(Expression<Func<Tag, bool>> filter = null)
        {
            var tag = _unitOfWork.Tags.GetAll(filter).Result;
            var tagModel = _mapper.Map<List<GetTagModel>>(tag);
            return tagModel;
        }

        public bool Update(int id, UpdateTagModel updateTagModel)
        {
            var tag = _unitOfWork.Tags.GetById(id).Result;
            updateTagModel.Id = id;
            _unitOfWork.Tags.Delete(tag);
            var result = _unitOfWork.Complete();
            return result > 0 ? true : false;
        }
    }
}

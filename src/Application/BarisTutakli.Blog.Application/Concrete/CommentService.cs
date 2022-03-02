using AutoMapper;
using BarisTutakli.Blog.Application.Models.CommentModels;
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
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public bool Add(CreateCommentModel createCommentModel)
        {
           var comment= _mapper.Map<Comment>(createCommentModel);
            _unitOfWork.Comments.Add(comment);
            var result = _unitOfWork.Complete();
            return result > 0 ? true : false; ;
        }

        public bool Delete(DeleteCommentModel deleteCommentModel)
        {
            var comment = _unitOfWork.Comments.GetById(deleteCommentModel.Id).Result;
            _unitOfWork.Comments.Delete(comment);
            var result = _unitOfWork.Complete();
            return result > 0 ? true : false;
        }

        public GetCommentModel Get(Expression<Func<Comment, bool>> filter)
        {
            var comment = _unitOfWork.Comments.Get(filter).Result;
            var commentModel = _mapper.Map<GetCommentModel>(comment);
            return commentModel;
        }


        public List<GetCommentModel> GetAll(Expression<Func<Comment, bool>> filter = null)
        {
            var comment = _unitOfWork.Comments.GetAll(filter).Result;
            var commentModel = _mapper.Map<List<GetCommentModel>>(comment);
            return commentModel;
        }

        public bool Update(int id, UpdateCommentModel updateCommentModel)
        {
            var comment = _unitOfWork.Comments.GetById(id).Result;
            updateCommentModel.Id = id;
            _unitOfWork.Comments.Delete(comment);
            var result = _unitOfWork.Complete();
            return result > 0 ? true : false;
        }
    }
}

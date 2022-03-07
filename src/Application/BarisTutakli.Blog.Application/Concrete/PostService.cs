using AutoMapper;
using BarisTutakli.Blog.Application.Models.PostModels;
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
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public bool Add(CreatePostModel createPostModel)
        {
            var post = _mapper.Map<Post>(createPostModel);
            _unitOfWork.Posts.Add(post);
            var result = _unitOfWork.Complete();
            return result > 0; 
        }

        public bool Delete(DeletePostModel deletePostModel)
        {
            var post = _unitOfWork.Posts.GetById(deletePostModel.Id).Result;
            _unitOfWork.Posts.Delete(post);
            var result = _unitOfWork.Complete();
            return result > 0;
        }

        public GetPostModel Get(Expression<Func<Post, bool>> filter)
        {
            var post = _unitOfWork.Posts.Get(filter).Result;
            var postModel = _mapper.Map<GetPostModel>(post);
            return postModel;
        }


        public List<GetPostModel> GetAll(Expression<Func<Post, bool>> filter = null)
        {
            var post = _unitOfWork.Posts.GetAll(filter).Result;
            var postModel = _mapper.Map<List<GetPostModel>>(post);
            return postModel;
        }

        public bool Update(int id, UpdatePostModel updatePostModel)
        {
            var post = _unitOfWork.Posts.GetById(id).Result;
            updatePostModel.Id = id;
            _unitOfWork.Posts.Delete(post);
            var result = _unitOfWork.Complete();
            return result > 0;
        }
    }
}

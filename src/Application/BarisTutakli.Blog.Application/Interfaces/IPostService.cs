using BarisTutakli.Blog.Application.Dto;
using BarisTutakli.Blog.Application.Models.PostModels;
using BarisTutakli.Blog.Application.Wrappers;
using BarisTutakli.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces
{
    public interface IPostService
    {
        Response<List<GetPostModel>> GetAll(Expression<Func<Post, bool>> filter = null);
        Response<GetPostModel> Get(Expression<Func<Post, bool>> filter);
        Response Add(CreatePostModel createPostModel);
        Response Update(int id,UpdatePostModel updatePostModel);
        Response Delete(DeletePostModel deletePostModel);
    }
}

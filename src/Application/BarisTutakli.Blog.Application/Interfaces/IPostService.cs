using BarisTutakli.Blog.Application.Dto;
using BarisTutakli.Blog.Application.Models.PostModels;
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
        List<GetPostModel> GetAll(Expression<Func<Post, bool>> filter = null);
        GetPostModel Get(Expression<Func<Post, bool>> filter);
        bool Add(CreatePostModel createPostModel);
        bool Update(int id,UpdatePostModel updatePostModel);
        bool Delete(DeletePostModel deletePostModel);
    }
}

using BarisTutakli.Blog.Application.Dto;
using BarisTutakli.Blog.Application.Models.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces
{
    public interface IPostService
    {
        List<GetPostModel> GetAll(Expression<Func<PostDto, bool>> filter = null);
        GetPostModel Get(Expression<Func<PostDto, bool>> filter);
        bool Add(CreatePostModel createPostModel);
        bool Update(int id,UpdatePostModel updatePostModel);
        bool Delete(DeletePostModel deletePostModel);
    }
}

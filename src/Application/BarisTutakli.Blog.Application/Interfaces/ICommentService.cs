using BarisTutakli.Blog.Application.Wrappers;
using BarisTutakli.Blog.Application.Models.CommentModels;
using BarisTutakli.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces
{
    public interface ICommentService
    {
        Response<List<GetCommentModel>> GetAll(Expression<Func<Comment, bool>> filter = null);
        Response<GetCommentModel> Get(Expression<Func<Comment, bool>> filter);
        Response Add(CreateCommentModel createCommentModel);
        Response Update(int id, UpdateCommentModel updateCommentModel);
        Response Delete(DeleteCommentModel deleteCommentModel);
    }
}

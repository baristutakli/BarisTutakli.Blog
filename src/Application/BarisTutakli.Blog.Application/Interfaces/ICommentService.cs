using BarisTutakli.Blog.Application.Dto;
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
        List<GetCommentModel> GetAll(Expression<Func<Comment, bool>> filter = null);
        GetCommentModel Get(Expression<Func<Comment, bool>> filter);
        bool Add(CreateCommentModel createCommentModel);
        bool Update(int id, UpdateCommentModel updateCommentModel);
        bool Delete(DeleteCommentModel deleteCommentModel);
    }
}

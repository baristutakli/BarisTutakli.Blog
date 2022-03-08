
using BarisTutakli.Blog.Application.Dto;
using BarisTutakli.Blog.Application.Models.TagModels;
using BarisTutakli.Blog.Application.Wrappers;
using BarisTutakli.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces
{
    public interface ITagService
    {
        Response<List<GetTagModel>> GetAll(Expression<Func<Tag, bool>> filter = null);
        Response<GetTagModel> Get(Expression<Func<Tag, bool>> filter);
        Response Add(CreateTagModel createTagModel);
        Response Update(int id, UpdateTagModel updateTagModel);
        Response Delete(DeleteTagModel deleteTagModel);
    }
}

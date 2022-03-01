
using BarisTutakli.Blog.Application.Dto;
using BarisTutakli.Blog.Application.ViewModels.TagViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces
{
    public interface ITagService
    {
        List<GetTagModel> GetAll(Expression<Func<TagDto, bool>> filter = null);
        GetTagModel Get(Expression<Func<TagDto, bool>> filter);
        bool Add(CreateTagModel createTagModel);
        bool Update(int id, UpdateTagModel updateTagModel);
        bool Delete(DeleteTagModel deleteTagModel);
    }
}

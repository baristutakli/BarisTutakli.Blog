using BarisTutakli.Blog.Application.Dto;
using BarisTutakli.Blog.Application.Models.TagModels;
using BarisTutakli.Blog.Application.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces
{
    public interface IUserService
    {
        List<GetUserModel> GetAll(Expression<Func<UserDto, bool>> filter = null);
        GetUserModel Get(Expression<Func<UserDto, bool>> filter);
        bool Add(CreateUserModel createUserModel);
        bool Update(int id, UpdateUserModel updateUserModel);
        bool Delete(DeleteUserModel deleteUserModel);
    }
}

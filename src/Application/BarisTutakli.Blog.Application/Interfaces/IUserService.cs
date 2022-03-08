using BarisTutakli.Blog.Application.Dto;
using BarisTutakli.Blog.Application.Models.TagModels;
using BarisTutakli.Blog.Application.Models.UserModels;
using BarisTutakli.Blog.Application.ViewModels.UserViewModels;
using BarisTutakli.Blog.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces
{
    public interface IUserService
    {
        Response<List<GetUserModel>> GetAll(Expression<Func<UserDto, bool>> filter = null);
        Response<GetUserModel> Get(Expression<Func<UserDto, bool>> filter);
        Response Add(CreateUserModel createUserModel);
        Response Update(int id, UpdateUserModel updateUserModel);
        Response Delete(DeleteUserModel deleteUserModel);
    }
}

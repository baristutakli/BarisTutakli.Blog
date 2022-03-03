using BarisTutakli.Blog.Application.Models.UserModels;
using BarisTutakli.Blog.Application.ViewModels.UserViewModels;
using BarisTutakli.Blog.Application.Wrappers;
using BarisTutakli.Blog.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Application.Interfaces
{
    public interface IAuthenticateService
    {
        public Task<IdentityResult> CreateUser(CreateUserModel model);
        public Task<Response<User>> CreateAdmin(CreateUserModel model);
        public Task<bool> CheckUser(User user, LoginViewModel model);
        public Task<bool> CreateAdminRole(User user, string role);
        public Task<User> FindByEmailAsync(string username);

    }
}

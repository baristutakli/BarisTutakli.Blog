using BarisTutakli.Blog.Application.Interfaces;
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

namespace BarisTutakli.Blog.Application.Concrete
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;

        public AuthenticateService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;

        }

        public async Task<Token> Login(LoginViewModel model)
        {
            // user locked out çalıştı bu kısmı düzenlemen gerek  
            var user = await FindByEmailAsync(model.Email);
          
            if (!await _userManager.IsLockedOutAsync(user))
            {
                if (await CheckUser(user, model))
                {

                    var token = await _tokenService.Create(user);
                    return token;
                }
            }
            return null;
        }
        public async Task<IdentityResult> CreateUser(CreateUserModel model)
        {
            User user = new User()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            return result;
        }

        public async Task<Response<User>> CreateAdmin(CreateUserModel model)
        {
            User user = new User()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            return new Response<User> { Data = user, Succeeded = result.Succeeded };
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user;
        }

        public async Task<bool> CheckUser(User user, LoginViewModel model)
        {
            return user != null && await _userManager.CheckPasswordAsync(user, model.Password);
        }


        public async Task<bool> CreateAdminRole(User user, string role)
        {
            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));
            if (!await _roleManager.RoleExistsAsync(ViewModels.UserViewModels.Roles.User))
                await _roleManager.CreateAsync(new IdentityRole(ViewModels.UserViewModels.Roles.User));

            if (await _roleManager.RoleExistsAsync(role))
            {
                await _userManager.AddToRoleAsync(user, role);
            }
            return true;
        }

    }
}

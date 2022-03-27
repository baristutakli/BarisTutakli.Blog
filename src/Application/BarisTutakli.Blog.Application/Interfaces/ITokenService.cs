using BarisTutakli.Blog.Application.Dto;
using BarisTutakli.Blog.Application.ViewModels.UserViewModels;
using BarisTutakli.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Application.Interfaces
{
    public interface ITokenService
    {
        Task<Token> Create(User user);
       object ValidateToken(string token);
    }
}

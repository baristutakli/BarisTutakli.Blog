using BarisTutakli.Blog.Application.Dto;
using BarisTutakli.Blog.Application.Interfaces;
using BarisTutakli.Blog.Application.ViewModels.UserViewModels;
using BarisTutakli.Blog.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Application.Concrete
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        public TokenService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<Token> Create(User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new Token
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };

        }
        public object ValidateToken(string token)
        {
            var mySecret = Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            var tokenHandler = new JwtSecurityTokenHandler();

            tokenHandler.ValidateToken(token,
            new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = _configuration["JWT:ValidIssuer"],
                ValidAudience = _configuration["JWT:ValidAudience"],
                IssuerSigningKey = mySecurityKey,
            }, out SecurityToken validatedToken);
            var jwtToken = (JwtSecurityToken)validatedToken;
            var userName = jwtToken.Claims.First().Value;
            var jti=jwtToken.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            var role = jwtToken.Claims.First(x=>x.Type== ClaimTypes.Role).Value;
            
            return new{ UserName=userName,Role=role };
        }
    }
}

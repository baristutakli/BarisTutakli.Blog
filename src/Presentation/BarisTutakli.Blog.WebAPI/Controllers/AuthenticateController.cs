using BarisTutakli.Blog.Application.Interfaces;
using BarisTutakli.Blog.Application.Models.UserModels;
using BarisTutakli.Blog.Application.ViewModels.UserViewModels;
using BarisTutakli.Blog.Application.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/Authenticate")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        public AuthenticateController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var token = await _authenticateService.Login(model);
            HttpContext.Response.Headers["Authentication"] = token.AccessToken;
            return token.AccessToken != null ? Ok() : Unauthorized();

        }
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserModel model)
        {
            var userExists = await _authenticateService.FindByEmailAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "User already exists!" });

            var result = await _authenticateService.CreateUser(model);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            await _authenticateService.CreateAdminRole(result.Data, Roles.User);

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        [Route("register/admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] CreateUserModel model)
        {
            var userExists = await _authenticateService.FindByEmailAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });


            var result = _authenticateService.CreateUser(model);

            if (!result.Result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            await _authenticateService.CreateAdminRole(result.Result.Data, Roles.Admin);

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
    }
}


using BarisTutakli.Blog.Application.Interfaces;
using BarisTutakli.Blog.Application.Wrappers;
using BarisTutakli.Blog.WebAPI.Common.Loggers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.WebAPI.Middleware
{
    
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
       // private readonly ITokenService _tokenService;
        private readonly ICrossCuttingConcernsFactory<string> _crossCuttingConcernsFactory;
        public CustomExceptionMiddleware(RequestDelegate next,  ICrossCuttingConcernsFactory<string> crossCuttingConcernsFactory)
        {
            _next = next;
          
            _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
        }
        public async Task Invoke(HttpContext context, ITokenService _tokenService)
        {
            var watch = Stopwatch.StartNew();
            try
            {

                string message = $"[Request HTTP] {context.Request.Method } -- {context.Request.Path}\n";
                _crossCuttingConcernsFactory.CreateMongoDBLogging().Log(new Logs<string>() { Data = message, Succeeded=true });

                var token = "";
                // user manager ı dail et ve veri tabanından token ı kontrol et
                if (context.Request.Headers["Authorization"].ToString().StartsWith("Bearer"))
                {
                    // reomves "Bearer " from the beginning of the token 
                    token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                    var user = _tokenService.ValidateToken(token);
                    // will be continued...   
                }


                await _next(context);
                watch.Stop();
                message = $"[Response HTTP] {context.Request.Method} -- {context.Request.Path} responded {context.Response.StatusCode} in {watch.Elapsed.TotalMilliseconds}ms\n";


              // _loggerService.Log(message);
            }
            catch (Exception ex)
            {

                watch.Stop();
                await HandleException(context, ex, watch);
            }


        }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = $"[Error] HTTP {context.Request.Method} -- {context.Response.StatusCode} Error Message: {ex.Message} in {watch.Elapsed.TotalMilliseconds}ms";
            var result = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.None);
            return context.Response.WriteAsync(result);
        }
    }
    public static class CustomExceptionMiddlewareExctension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}

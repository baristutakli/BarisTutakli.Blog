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
        private readonly ILoggerService _loggerService;
        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }
        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            try
            {

                string message = $"[Request HTTP] {context.Request.Method } -- {context.Request.Path}\n";

                _loggerService.Log(message);

                //ReadToken
                //var token = "";
                //if (context.Request.Headers["Authorization"].ToString().Length > 20)
                //{

                //    token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                //    var mySecret = Encoding.UTF8.GetBytes("ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM");
                //    var mySecurityKey = new SymmetricSecurityKey(mySecret);
                //    var tokenHandler = new JwtSecurityTokenHandler();

                //    tokenHandler.ValidateToken(token,
                //    new TokenValidationParameters
                //    {
                //        ValidateIssuerSigningKey = true,
                //        ValidateIssuer = true,
                //        ValidateAudience = true,
                //        ValidIssuer = "http://localhost:5000/",
                //        ValidAudience = "http://localhost:5000/",
                //        IssuerSigningKey = mySecurityKey,
                //    }, out SecurityToken validatedToken);
                //}






                await _next(context);
                watch.Stop();
                message = $"[Response HTTP] {context.Request.Method} -- {context.Request.Path} responded {context.Response.StatusCode} in {watch.Elapsed.TotalMilliseconds}ms\n";


                _loggerService.Log(message);
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
            _loggerService.Log(message);
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

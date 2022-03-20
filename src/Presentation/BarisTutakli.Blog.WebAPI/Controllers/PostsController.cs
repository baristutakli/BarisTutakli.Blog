using BarisTutakli.Blog.Application.Models.PostModels;
using BarisTutakli.Blog.Application.Tools.JsonConverterTools;
using Blog.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.WebAPI.Controllers
{
    [Route("api/Posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;

        }
        // GET: api/<PostsController>
        [HttpGet]
        public IActionResult Get()
        {
            var posts = _postService.GetAll();
            return Ok(posts);
        }

        // GET api/<PostsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _postService.Get(c => c.Id == id);

            return Ok(post);
        }

        // POST api/<PostsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreatePostModel createPostModel)
        {
            return _postService.Add(createPostModel).Status == "Success" ? StatusCode(StatusCodes.Status201Created) : StatusCode(StatusCodes.Status500InternalServerError);
        }

        // PUT api/<PostsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdatePostModel updatePostModel)
        {

            return _postService.Update(id, updatePostModel).Status == "Success" ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeletePostModel deletePost = new DeletePostModel() { Id = id };
            return _postService.Delete(deletePost).Status == "Success" ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}


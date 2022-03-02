using BarisTutakli.Blog.Application.Models.PostModels;
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
        private IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;

        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _postService.GetAll();
            return Ok(JsonConvert.SerializeObject(categories, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _postService.Get(c => c.Id == id);

            return Ok(JsonConvert.SerializeObject(post, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult Post([FromBody] CreatePostModel createPostModel)
        {
            return _postService.Add(createPostModel) == true ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdatePostModel updatePostModel)
        {

            return _postService.Update(id, updatePostModel) == true ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeletePostModel deletePost = new DeletePostModel() { Id = id };
            return _postService.Delete(deletePost) == true ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}


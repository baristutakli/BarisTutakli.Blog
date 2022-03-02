using BarisTutakli.Blog.Application.Models.CommentModels;
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
    [Route("api/Comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;

        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _commentService.GetAll();
            return Ok(JsonConvert.SerializeObject(categories, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var comment = _commentService.Get(c => c.Id == id);

            return Ok(JsonConvert.SerializeObject(comment, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateCommentModel createCommentModel)
        {
            return _commentService.Add(createCommentModel) == true ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCommentModel updateCommentModel)
        {

            return _commentService.Update(id, updateCommentModel) == true ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteCommentModel deleteComment = new DeleteCommentModel() { Id = id };
            return _commentService.Delete(deleteComment) == true ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}

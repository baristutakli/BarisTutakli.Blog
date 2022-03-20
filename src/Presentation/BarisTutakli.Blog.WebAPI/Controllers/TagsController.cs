using BarisTutakli.Blog.Application.Models.TagModels;
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
    [Route("api/Tags")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;

        }
        // GET: api/<TagsController>
        [HttpGet]
        public IActionResult Get()
        {
            var tags = _tagService.GetAll();
            return Ok(tags);
        }

        // GET api/<TagsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var tag = _tagService.Get(c => c.Id == id);

            return Ok(tag);
        }

        // POST api/<TagsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateTagModel createTagModel)
        {
            return _tagService.Add(createTagModel).Status == "Success" ? StatusCode(StatusCodes.Status201Created) : StatusCode(StatusCodes.Status500InternalServerError);
        }

        // PUT api/<TagsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateTagModel updateTagModel)
        {

            return _tagService.Update(id, updateTagModel).Status == "Success" ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }

        // DELETE api/<TagsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteTagModel deleteTag = new DeleteTagModel() { Id = id };
            return _tagService.Delete(deleteTag).Status == "Success" ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}

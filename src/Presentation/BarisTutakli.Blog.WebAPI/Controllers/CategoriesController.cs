using BarisTutakli.Blog.Application.Models.CategoryModels;
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
    [Route("api/Categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _categoryService.GetAll();
            return Ok(categories);
        }
        [HttpGet("titles")]
        //[Route("/titles")]
        public IActionResult GetTitles()
        {
            var categories = _categoryService.GetTitles();
            return Ok(categories);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _categoryService.Get(c=>c.Id==id);

            return Ok(category);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateCategoryModel createCategoryModel)
        {
            return _categoryService.Add(createCategoryModel).Status=="Success" ? StatusCode(StatusCodes.Status201Created) : StatusCode(StatusCodes.Status500InternalServerError);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCategoryModel updateCategoryModel)
        {

            return _categoryService.Update(id, updateCategoryModel).Status=="Success" ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteCategoryModel deleteCategory = new DeleteCategoryModel() { Id = id };
            return _categoryService.Delete(deleteCategory).Status == "Success" ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}

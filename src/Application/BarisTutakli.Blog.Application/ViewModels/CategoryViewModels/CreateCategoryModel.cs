using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BarisTutakli.Blog.Application.Models.CategoryModels
{
    public class CreateCategoryModel
    {
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Body { get; set; }
    }
}

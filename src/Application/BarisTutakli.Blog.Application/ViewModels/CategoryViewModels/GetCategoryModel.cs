using BarisTutakli.Blog.Application.Models.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Application.Models.CategoryModels
{
    public class GetCategoryModel
    {

 
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Body { get; set; }
        public virtual ICollection<GetPostModel> Posts { get; set; }
    }
}

using BarisTutakli.Blog.Application.Dto;
using BarisTutakli.Blog.Application.Models.CategoryModels;
using BarisTutakli.Blog.Application.Models.TagModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Application.Models.PostModels
{
   public class GetPostModel
    {
        public UserDto User { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Summary { get; set; }
        public bool Published { get; set; }
        public short? Likes { get; set; }
        public short? Dislike { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Body { get; set; }
        public virtual ICollection<GetCategoryTitleModel> Categories { get; set; }
        public virtual ICollection<GetTagTitleModel> Tags { get; set; }
    }
}

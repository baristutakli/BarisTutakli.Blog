using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BarisTutakli.Blog.Application.Models.PostModels;

namespace BarisTutakli.Blog.Application.Models.TagModels
{
    public class GetTagModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<GetPostModel> Posts { get; set; }
    }
}

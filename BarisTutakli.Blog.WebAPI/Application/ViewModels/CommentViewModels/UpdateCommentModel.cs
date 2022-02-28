using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BarisTutakli.Blog.WebAPI.Application.ViewModels.CommentViewModels
{
    public class UpdateCommentModel
    {

        public string Title { get; set; }
        public bool Published { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Contents { get; set; }
    }
}

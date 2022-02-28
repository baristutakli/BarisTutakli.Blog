using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BarisTutakli.Blog.WebAPI.Application.ViewModels.TagViewModels
{
    public class CreateTagModel
    {
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Body { get; set; }
    }
}

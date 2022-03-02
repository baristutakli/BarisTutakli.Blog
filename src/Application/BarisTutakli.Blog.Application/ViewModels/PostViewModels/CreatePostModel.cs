
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarisTutakli.Blog.Application.Models.PostModels

{   
    public class CreatePostModel
    {
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Summary { get; set; }
        public bool Published { get; set; }
        public string Body { get; set; }
        public  string Categories { get; set; }
        public  string Tags { get; set; }
    }
}

using BarisTutakli.Blog.Application.Models.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Application.Models.UserModels
{
    public class GetUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Intro { get; set; }
        public virtual ICollection<GetPostModel> Posts { get; set; }
    }
}

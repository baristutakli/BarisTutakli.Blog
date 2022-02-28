using BarisTutakli.Blog.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public Tag()
        {
            CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
            IsActive = true;
        }

        [Required]
        [MaxLength(75)]
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        [Required]
        public string Body { get; set; }
        public virtual ICollection<Post> Posts { get; set; }


    }
}

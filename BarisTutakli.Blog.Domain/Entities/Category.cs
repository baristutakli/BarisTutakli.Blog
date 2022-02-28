using BarisTutakli.Blog.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            CreatedAt = DateTime.Parse( DateTime.Now.ToShortDateString());
            IsActive = true;
        }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(50)]
        public string MetaTitle { get;  set; }

        [MaxLength(300)]
        public string Body { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}

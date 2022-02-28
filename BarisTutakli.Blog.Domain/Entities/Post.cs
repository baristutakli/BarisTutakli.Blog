using BarisTutakli.Blog.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Domain.Entities
{
    public class Post : BaseEntity
    {
        public Post()
        {
            CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
            IsActive = true;
        }

        [Required]
        public User User { get; set; }
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        [MaxLength(300)]
        public string Summary { get; set; }
        public bool Published { get; set; }
        public DateTime UpdatedAt { get; set; }
        public short? Likes { get; set; }
        public short? Dislike { get; set; }
        public DateTime PublishedAt { get; set; }
        [Required]
        public string Body { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}

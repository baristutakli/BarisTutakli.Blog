using BarisTutakli.Blog.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public Comment()
        {
            CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
            IsActive = true;
        }

        [Required]
        public User User { get; set; }
        [Required]
        public Post Post { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public bool Published { get;  set; }
        public DateTime PublishedAt { get; set; }
        [MaxLength(500)]
        public string Body { get; set; }
    }
}

using BarisTutakli.Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Application.Interfaces
{
   public  interface IBlogContext
    {
      DbSet<Category> Categories { get; set; }
      DbSet<Comment> Comments { get; set; }
      DbSet<Post> Posts { get; set; }
      DbSet<Tag> Tags { get; set; }
      DbSet<User> Users { get; set; }
    }
}

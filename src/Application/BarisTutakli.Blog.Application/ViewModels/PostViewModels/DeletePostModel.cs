using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace BarisTutakli.Blog.Application.Models.PostModels
{
    [NotMapped]
    public class DeletePostModel
    {
        public int Id { get; set; }
    }
}

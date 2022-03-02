using BarisTutakli.Blog.Application.Wrappers;
using BarisTutakli.Blog.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Application.Interfaces
{
    public interface IRabbitMQService
    {
        Response SendEmailIntoQueue(MailResponse mailResponse);
    }
}

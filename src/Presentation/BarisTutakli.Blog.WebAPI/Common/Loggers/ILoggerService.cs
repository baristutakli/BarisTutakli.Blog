using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.WebAPI.Common.Loggers
{
    public interface ILoggerService
    {
        public void Log(string message);
    }
}

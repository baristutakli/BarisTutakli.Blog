using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Application.Interfaces
{
    public interface ICrossCuttingConcernsFactory<T> where T:class
    {
        ILoggerService<T> CreateMongoDBLogging();
        ILoggerService<T> CreateFileLogging();
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Application.Wrappers
{
 
    public class Logs<T>
    {
        [BsonId]
        public Guid Id { get; set; }
        public Logs()
        {

            Id = Guid.NewGuid();
        }
        //Guid.NewGuid().ToString().Substring(0, 11);
        public Logs(T data)
        {
            Id = Guid.NewGuid();
            Succeeded = true;
            Message = string.Empty;
            Data = data;
        }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}

using BarisTutakli.Blog.Application.Wrappers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Application.Tools.JsonConverterTools
{
    public static class CustomJsonConverter<T> where T:class
    {
        public static string ConvertResponse(Response<T> response)
        {
            return JsonConvert.SerializeObject(response, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
        public static string ConvertResponse(Response response)
        {
            return JsonConvert.SerializeObject(response, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}

using BarisTutakli.Blog.Application.Interfaces;
using BarisTutakli.Blog.Application.Wrappers;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarisTutakli.Blog.Application.Concrete
{
    public class FileLoggerService<T>:ILoggerService<T> where T : class
    {

        private readonly IWebHostEnvironment _hostingEnvironment;
        public FileLoggerService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public void Log(Logs<T> logs)
        {
            Console.WriteLine($"[FileLogger]: {System.Text.Json.JsonSerializer.Serialize(logs)}");

            // This code log messages into documents directory
            string mainPath = _hostingEnvironment.ContentRootPath;
            ////string filePath = $"{mainPath}\\LogFiles\\";
            //string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //if (!Directory.Exists(docPath))
            //{
            //    Directory.CreateDirectory(docPath);
            //}
            //// Write the specified text asynchronously to a new file named "WriteTextAsync.txt".
            //using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, 
            //    "RequestAndResponseLogger.txt"),true))
            //{
            //    outputFile.Write(message);
            //}

        }
    }
}

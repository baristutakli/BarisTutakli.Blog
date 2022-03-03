using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace BarisTutakli.Blog.WebAPI.Common.Loggers
{
    public class FileLogger : ILoggerService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public FileLogger(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        
        public void Log(string message)
        {
            Console.WriteLine($"[FileLogger]: {message}");

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

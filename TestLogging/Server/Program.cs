using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestLogging.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Serilog.Debugging.SelfLog.Enable(m => Console.Error.WriteLine(m));
            var currentDirectory = Directory.GetCurrentDirectory();
            Log.Logger = new LoggerConfiguration()
                 .MinimumLevel.Warning()
                 //  .Enrich.FromLogContext()
                 .WriteTo.File(new JsonFormatter(), $"{currentDirectory}//Logs//Log.txt", shared: true)
                 .CreateLogger();





            Log.Information("hi im a log");
                
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                });
    }
}

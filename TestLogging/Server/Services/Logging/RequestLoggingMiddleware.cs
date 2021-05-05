using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestLogging.Server.Services.Logging
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILogger _logger;
        public RequestLoggingMiddleware(RequestDelegate next/*, ILoggerFactory loggerFactory*/)
        {
            _next = next;
           // _logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                //_logger.LogInformation(
                //    "Request {method} {url} => {statusCode}",
                //    context.Request?.Method,
                //    context.Request?.Path.Value,
                //    context.Response?.StatusCode);

                Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
           .Enrich.FromLogContext()
           .WriteTo.Console()
           .CreateLogger();

            }
        }
    }
}

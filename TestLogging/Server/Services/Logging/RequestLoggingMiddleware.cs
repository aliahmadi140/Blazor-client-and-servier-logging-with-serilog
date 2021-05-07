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
       
        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
           
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                if (context.Response.StatusCode != StatusCodes.Status200OK)
                {
                    Log.Error(
                   "Request {method} { url} => { statusCode} ",
              context.Request?.Method,
              context.Request?.Path.Value,
              context.Response?.StatusCode);
                }


            }
        }
    }
}

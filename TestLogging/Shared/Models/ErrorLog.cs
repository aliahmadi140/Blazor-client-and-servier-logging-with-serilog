using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestLogging.Shared.Models
{
    public static class ErrorLog
    {
        public static void ProcessError(Exception ex)
        {
            Log.Error("Error:ProcessError - Type: {Type} Message: {Message}",
                ex.GetType(), ex.Message);
        }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;
using Serilog.Context;

namespace AsyncWebApi.Middleware
{
    class RequestIdMiddleware
    {
        readonly RequestDelegate _next;

        static int _nextRequestId = 0;

        public RequestIdMiddleware(RequestDelegate next)
        {
            if (next == null) throw new ArgumentNullException(nameof(next));
            _next = next;
        }
        
        public async Task Invoke(HttpContext context)
        {
            var requestId = Interlocked.Increment(ref _nextRequestId);
            using (LogContext.PushProperty("MyRequestId", requestId))
            {
                await _next.Invoke(context);
            }
        }
    }
}

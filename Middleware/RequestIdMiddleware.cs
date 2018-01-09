using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncWebApi.Middleware
{
    class RequestIdMiddleware
    {
        readonly RequestDelegate _next;

        static int _nextId = 0;

        public RequestIdMiddleware(RequestDelegate next)
        {
            if (next == null) throw new ArgumentNullException(nameof(next));
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            var nextId = Interlocked.Increment(ref _nextId);
            var formattedNextId = $"{nextId:D8}";
            httpContext.Items.Add("requestId", formattedNextId);
            await _next(httpContext);
        }
    }
}

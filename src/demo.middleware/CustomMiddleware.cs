using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace demo.middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("{'Custom middleware':'");
            await _next(httpContext);
            await httpContext.Response.WriteAsync("'}");
        }
    }
}
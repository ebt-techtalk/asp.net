using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace demo.middleware
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("{'Inline middleware':'");
                await next.Invoke();
                await context.Response.WriteAsync("'}");
            });
            app.UseCustomMiddleware();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("demo.middleware");
            });
        }
    }
}
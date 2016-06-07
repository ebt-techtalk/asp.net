using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace demo.di
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<INotificationService, MailNotificationService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                IServiceProvider services = context.RequestServices;
                var mail = services.GetService<INotificationService>();
                await mail.NotifyUser("user@example.com", "Hello, User");
                await context.Response.WriteAsync("demo.di, user notified");
            });
        }
    }
}
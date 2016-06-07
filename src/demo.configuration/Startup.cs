using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace demo.configuration
{
    public class Startup
    {
        private IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            if (!env.IsDevelopment())
            {
                builder.AddUserSecrets();
            }
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<CustomConfiguration>(Configuration);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                var connectionString = Configuration["Data:DefaultConnection:ConnectionString"];
                var configurationOptions = context.RequestServices.GetRequiredService<IOptions<CustomConfiguration>>();
                var customConfiguration = configurationOptions.Value;
                await context.Response.WriteAsync($"demo.configuration, connection string = {connectionString}, service bus endpoint = {customConfiguration.ServiceBus.Endpoint}");
            });
        }
    }
}
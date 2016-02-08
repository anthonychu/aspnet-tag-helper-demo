using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using GiphyTagHelper;
using Microsoft.Extensions.Configuration;

namespace TagHelperDemo.Mvc
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            Configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGiphyTagHelper(new GiphyTagHelperConfiguration(Configuration["giphy:apiKey"]));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseIISPlatformHandler();
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}

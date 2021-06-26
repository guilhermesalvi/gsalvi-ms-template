using GSalvi.Template.Api.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSalvi.Template.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDocumentationConfig();
            services.AddMessageManagerConfig();
            services.AddVersioningConfig();
            services.AddMediatRConfig();
            services.AddPipelineBehaviorsConfig();
            services.AddPresentersConfig();
            services.AddControllersConfig();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMessageManagerConfig();
            app.UseDocumentationConfig();
            app.UseGlobalExceptionHandlerConfig(env);
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseControllersConfig();
        }
    }
}
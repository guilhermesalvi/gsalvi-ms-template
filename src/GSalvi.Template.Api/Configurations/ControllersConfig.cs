using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace GSalvi.Template.Api.Configurations
{
    public static class ControllersConfig
    {
        public static void AddControllersConfig(this IServiceCollection services)
        {
            services
                .AddControllers()
                .ConfigureApiBehaviorOptions(options => options.SuppressMapClientErrors = true);
        }

        public static void UseControllersConfig(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
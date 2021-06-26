using GSalvi.MessageManager;
using GSalvi.Template.Api.LocalizationResources;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Globalization;

namespace GSalvi.Template.Api.Configurations
{
    public static class MessageManagerConfig
    {
        public static void AddMessageManagerConfig(this IServiceCollection services)
        {
            services.AddMessageManager<SharedResource>(options => options.ResourcesPath = "LocalizationResources");
        }

        public static void UseMessageManagerConfig(this IApplicationBuilder app)
        {
            app.UseMessageManager(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("pt-br");
                options.SupportedCultures = new List<CultureInfo>
                {
                    new("pt-br"),
                    new("en-us")
                };
            });
        }
    }
}
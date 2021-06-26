using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GSalvi.Template.Api.Configurations
{
    public static class MediatRConfig
    {
        public static void AddMediatRConfig(this IServiceCollection services)
        {
            services.AddMediatR(
                Assembly.GetExecutingAssembly(),
                Assembly.Load("GSalvi.Template.Application"));
        }
    }
}
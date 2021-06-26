using System.Collections.Generic;
using FluentValidation;
using GSalvi.Template.Application.PipelineBehavior;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GSalvi.Template.Api.Configurations
{
    public static class PipelineBehaviorsConfig
    {
        public static void AddPipelineBehaviorsConfig(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(InputValidatorPipelineBehavior<,>));

            var assemblies = new List<Assembly>
            {
                Assembly.GetExecutingAssembly(),
                Assembly.Load("GSalvi.Template.Application"),
                Assembly.Load("GSalvi.Template.Domain")
            };

            AssemblyScanner
                .FindValidatorsInAssemblies(assemblies)
                .ForEach(x => services.AddScoped(x.InterfaceType, x.ValidatorType));
        }
    }
}
using GSalvi.MessageManager;
using GSalvi.Template.Api.Controllers.Responses;
using GSalvi.Template.Domain.MessageSummaries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace GSalvi.Template.Api.Configurations
{
    public static class GlobalExceptionHandlerConfig
    {
        public static void UseGlobalExceptionHandlerConfig(
            this IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                return;
            }

            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";

                    var notificationManager = app.ApplicationServices.GetService<INotificationManager>();
                    notificationManager?.AddNotification(DefaultApplicationMessageSummary.DefaultApiError);
                    var notification = notificationManager?.Notifications.FirstOrDefault();

                    await context.Response.WriteAsync(JsonSerializer.Serialize(new Response<object>
                    {
                        Succeeded = false,
                        Data = null,
                        Errors = new List<ResponseError>
                        {
                            new()
                            {
                                Code = notification?.Key,
                                Description = notification?.Value
                            }
                        }
                    }));
                });
            });
        }
    }
}
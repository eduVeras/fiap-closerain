using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Fiap.CloseRain.Extensions
{
    public static  class ApplicationBuilserExtensions
    {
        public static IApplicationBuilder ExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        var ex = error.Error;

                        await context.Response.WriteAsync(new 
                        {
                            StatusCode = 500,
                            ErrorMessage = ex.Message
                        }.ToString()); 
                    }
                });
            });

            return app;
        }
    }
}

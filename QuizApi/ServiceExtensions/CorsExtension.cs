using Microsoft.Extensions.DependencyInjection;

namespace QuizApp.ServiceExtensions
{
    public static class CorsExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin());
            });
        }
    }
}
